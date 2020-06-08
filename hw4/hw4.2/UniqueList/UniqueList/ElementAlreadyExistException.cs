using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Class with implementation exception element already exist.
    /// </summary>
    public class ElementAlreadyExistException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementAlreadyExistException"/> class.
        /// </summary>
        public ElementAlreadyExistException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ElementAlreadyExistException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementAlreadyExistException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ElementAlreadyExistException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementAlreadyExistException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ElementAlreadyExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}