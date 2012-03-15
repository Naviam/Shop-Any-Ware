// -----------------------------------------------------------------------
// <copyright file="ValueObjectIsInvalidException.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System;

    /// <summary>
    /// If a value object is not created in a valid state, this exception should be thrown.
    /// </summary>
    public class ValueObjectIsInvalidException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueObjectIsInvalidException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ValueObjectIsInvalidException(string message) : base(message)
        {
        }
    }
}