using MoonSharp.Interpreter;
using System;

namespace Dibware.MoonsharpExtensions.InterpreterExtensions
{
    /// <summary>
    /// Encapsualates extension methods for the MoonSharp.Interpreter.Closure object
    /// </summary>
    public static class ClosureExtensions
    {
        /// <summary>
        /// Converts this instance to a delegate with one input parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="instance">The instance of the closure.</param>
        /// <returns></returns>
        public static Func<T1, TResult> ToDelegate<T1, TResult>(this Closure instance)
        {
            Func<T1, TResult> result =
                (arg1) => instance.Call(arg1).ToObject<TResult>();
            return result;
        }

        /// <summary>
        /// Converts this instance to a delegate with two input parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="instance">The instance of the closure.</param>
        /// <returns></returns>
        public static Func<T1, T2, TResult> ToDelegate<T1, T2, TResult>(this Closure instance)
        {
            Func<T1, T2, TResult> result =
                (arg1, arg2) => instance.Call(arg1, arg2).ToObject<TResult>();
            return result;
        }

        /// <summary>
        /// Converts this instance to a delegate with three input parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="instance">The instance of the closure.</param>
        /// <returns></returns>
        public static Func<T1, T2, T3, TResult> ToDelegate<T1, T2, T3, TResult>(this Closure instance)
        {
            Func<T1, T2, T3, TResult> result =
                (arg1, arg2, arg3) => instance.Call(arg1, arg2, arg3).ToObject<TResult>();
            return result;
        }
    }
}