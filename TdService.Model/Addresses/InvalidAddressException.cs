// -----------------------------------------------------------------------
// <copyright file="InvalidAddressException.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using System;

    /// <summary>
    /// Invalid address exception.
    /// </summary>
    [Serializable]
    public class InvalidAddressException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAddressException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidAddressException(string message) : base(message)
        {
        }
    }
}