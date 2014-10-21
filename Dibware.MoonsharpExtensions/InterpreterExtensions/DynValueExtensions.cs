using Dibware.Helpers.Validation;
using Dibware.MoonsharpExtensions.Exceptions;
using Dibware.MoonsharpExtensions.Resources;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;

namespace Dibware.MoonsharpExtensions.InterpreterExtensions
{
    /// <summary>
    /// Encapsualates extension methods for the MoonSharp.Interpreter.DynValue object
    /// </summary>
    public static class DynValueExtensions
    {
        /// <summary>
        /// Holds all of the acceptable types that a DynValu can be cast to
        /// </summary>
        private static List<Type> _acceptedTypes;

        /// <summary>
        /// Initializes the <see cref="DynValueExtensions"/> class.
        /// </summary>
        static DynValueExtensions()
        {
            InitialiseAcceptedTypes();
        }

        /// <summary>
        /// Initialises the accepted types.
        /// </summary>
        private static void InitialiseAcceptedTypes()
        {
            _acceptedTypes = new List<Type>();
            _acceptedTypes.Add(typeof(Double));
            _acceptedTypes.Add(typeof(String));
        }

        /// <summary>
        /// Gets the member specified by key.
        /// </summary>
        /// <param name="instance">The instance to get member from.</param>
        /// <param name="key">The key of the member to get.</param>
        /// <returns>
        /// Returns the value of the member, or null if the member does not exist.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the key is null or empty
        /// </exception>
        public static DynValue GetMember(this DynValue instance, String key)
        {
            // Guard against a NULL key having been supplied
            Guard.ArgumentIsNotNullOrEmpty(key, "key");

            // Get the value. This will throw an "System.ArgumentOutOfRangeException"
            // for us if the key does not exist. However See DEV NOTE above...
            var tableValue = instance.Table.Get(key);

            // Get the type of the table value
            DataType tableValueDataType = tableValue.Type;

            // See if a nil type was returned indicating the key did not exist...
            if (tableValueDataType == DataType.Nil)
            {
                // .. and return null
                return null;
            }

            // Return the table value as it is
            return tableValue;
        }

        /// <summary>
        /// Gets the value of the property defined by the specified key.
        /// </summary>
        /// <typeparam name="T">Defines thr expected return type.</typeparam>
        /// <param name="instance">The instance to get property from.</param>
        /// <param name="key">The key of the property to get.</param>
        /// <returns>
        /// Returns the value of the property, or the default value for the 
        /// target type if the property does not exist.
        /// </returns>
        /// <exception cref="TypeParameterException">
        /// Thrown if the target type is not in the acceptable list of CLR types
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if the key is null or empty
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Thrown if the source (property value) and target types do not match
        /// </exception>
        public static T GetPropertyValue<T>(this DynValue instance, String key)
        {
            // DEV NOTE:
            // Need to refactor this method to use the "GetMember()" method once
            // it has passed tests...

            // Get the target type
            Type targetType = typeof(T);

            // Guard against un-acceptable types, throw exception
            if (!_acceptedTypes.Contains(targetType))
            {
                throw new TypeParameterException(ExceptionMesssages.InvalidTypeParameterEncountered);
            }

            // Guard against a NULL key having been supplied
            if (String.IsNullOrEmpty(key))
            {
                throw new ArgumentOutOfRangeException(ExceptionMesssages.KeyNotNull);
            }

            // DEV NOTE:
            // Ideally we would like to check if the key exists in the table 
            // before trying to access the value, but there is no method to
            // acheive this with a String key parameter. Instead we will have 
            // to do this later after trying to get the value.
            //if (instance.Table.Values.Contains(key))
            //{
            //    throw new ArgumentOutOfRangeException(ExceptionMesssages.NoValueWasFoundForTheSuppliedKey);
            //}

            // Get the value. This will throw an "System.ArgumentOutOfRangeException"
            // for us if the key does not exist. However See DEV NOTE above...
            var tableValue = instance.Table.Get(key);

            // Get the type of the table value
            DataType tableValueDataType = tableValue.Type;

            // See if a nil type was returned indicating the key did not exist
            if (tableValueDataType == DataType.Nil)
            {
                return default(T);
            }

            // Ensure the value Type and the specified return type match
            if (targetType != GetMappedCLRType(tableValueDataType))
            {
                // They don't so throw a casting exception
                String errorMessage = String.Format(
                    ExceptionMesssages.CannotCastSourceToTarget,
                    tableValueDataType.ToString(),
                    targetType.ToString()
                );
                throw new InvalidCastException(errorMessage);
            }

            // Return the table value cast as the desired Type
            return (T)tableValue.ToObject<T>();
        }

        /// <summary>
        /// Gets the mapped CLR type for the specifed DataType.
        /// </summary>
        /// <param name="tableValueDataType">Type of the table value data.</param>
        /// <returns></returns>
        private static Type GetMappedCLRType(DataType tableValueDataType)
        {
            Type result = null;
            String notSupportedType = @"Unknown";

            switch (tableValueDataType)
            {
                case DataType.Boolean:
                    result = typeof(Boolean);
                    break;

                //case DataType.ClrFunction:
                //    break;
                //case DataType.Function:
                //    break;
                //case DataType.Nil:
                //    break;

                case DataType.Number:
                    result = typeof(Double);
                    break;

                case DataType.String:
                    result = typeof(String);
                    break;

                //case DataType.Table:
                //    break;
                //case DataType.TailCallRequest:
                //    break;
                //case DataType.Thread:
                //    break;
                //case DataType.Tuple:
                //    break;
                //case DataType.UserData:
                //    break;
                //case DataType.YieldRequest:
                //    break;

                default:
                    // Catch everything else
                    notSupportedType = tableValueDataType.ToString();
                    break;
            }

            // check if we populated the result
            if (result == null)
            {
                // We didn;t so throw an exception
                String errorMessage = String.Format(
                    ExceptionMesssages.DataTypeNotSupported,
                    notSupportedType
                );
                throw new TypeParameterException(errorMessage);
            }

            // We got here so must have a result we can return
            return result;
        }
    }
}