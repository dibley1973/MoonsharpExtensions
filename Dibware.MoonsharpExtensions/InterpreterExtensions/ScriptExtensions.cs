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
        /// Gets the object.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
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