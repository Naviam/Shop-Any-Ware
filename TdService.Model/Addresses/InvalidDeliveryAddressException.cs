// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidDeliveryAddressException.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Invalid delivery address exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using System;

    /// <summary>
    /// Invalid delivery address exception.
    /// </summary>
    [Serializable]
    public class InvalidDeliveryAddressException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDeliveryAddressException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidDeliveryAddressException(string message) : base(message)
        {
        }
    }
}