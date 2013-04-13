// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidItemException.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The invalid item exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System;

    /// <summary>
    /// The invalid item exception.
    /// </summary>
    public class InvalidItemException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidItemException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}