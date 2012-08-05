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
        public InvalidItemException(string message) : base(message)
        {
        }
    }
}