// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOrderException.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The invalid order exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// The invalid order exception.
    /// </summary>
    [Serializable]
    public class InvalidOrderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOrderException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidOrderException(string message) : base(message)
        {
        }
    }
}