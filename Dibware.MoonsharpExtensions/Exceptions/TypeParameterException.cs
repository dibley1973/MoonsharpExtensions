using System;
using System.Runtime.Serialization;

namespace Dibware.MoonsharpExtensions.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the type param provided to a method is not valid.
    /// </summary>
    [Serializable]
    public class TypeParameterException : ArgumentException
    {
        /// <summary>
        /// The default message for this instance if no message has been supplied 
        /// in a constructor.
        /// </summary>
        private const String DEFAULT_MESSAGE =
            "Type parameter does not fall into expected range";

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeParameterException"/> class.
        /// </summary>
        public TypeParameterException()
            : base(DEFAULT_MESSAGE) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeParameterException"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        public TypeParameterException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeParameterException" /> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception. If the 
        /// <paramref name="innerException" /> parameter is not a null reference, 
        /// the current exception is raised in a catch block that handles the 
        /// inner exception.
        /// </param>
        public TypeParameterException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeParameterException"/> class.
        /// </summary>
        /// <param name="info">
        /// The object that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The contextual information about the source or destination.
        /// </param>
        protected TypeParameterException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}