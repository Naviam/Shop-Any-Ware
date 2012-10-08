// -----------------------------------------------------------------------
// <copyright file="InvalidRetailerException.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// Invalid retailer exception.
    /// </summary>
    public class InvalidRetailerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRetailerException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidRetailerException(string message) : base(message)
        {
        }
    }
}