// -----------------------------------------------------------------------
// <copyright file="InvalidUserException.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;

    /// <summary>
    /// Invalid user exception.
    /// </summary>
    public class InvalidUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidUserException(string message) : base(message)
        {
        }
    }
}