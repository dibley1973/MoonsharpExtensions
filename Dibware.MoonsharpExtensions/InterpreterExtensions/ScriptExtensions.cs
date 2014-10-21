using Dibware.Helpers.Validation;
using MoonSharp.Interpreter;
using System;

namespace Dibware.MoonsharpExtensions.InterpreterExtensions
{
    /// <summary>
    /// Encapsulates extension methods for the MoonSharp.Interpreter.Script object
    /// </summary>
    public static class ScriptExtensions
    {
        /// <summary>
        /// Gets the object specified.
        /// </summary>
        /// <param name="instance">The script instance to get the object from.</param>
        /// <param name="key">The key of teh object to get.</param>
        /// <returns>
        /// Returns DynValue of type Table for a valid key or a DynValue with a 
        /// DataType of Nil if teh key is invalid
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the key is null or empty
        /// </exception>
        public static DynValue GetObject(this Script instance, String key)
        {
            // Guard against a NULL key having been supplied
            Guard.ArgumentIsNotNullOrEmpty(key, "key");

            var objectValue = instance.Globals.Get(key);

            return objectValue;
        }
    }
}