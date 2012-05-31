// -----------------------------------------------------------------------
// <copyright file="InvalidProfileException.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;

    /// <summary>
    /// Invalid profile exception.
    /// </summary>
    public class InvalidProfileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidProfileException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidProfileException(string message) : base(message)
        {
        }
    }
}