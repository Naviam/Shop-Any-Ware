// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPackageException.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The invalid package exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages.Exceptions
{
    using System;

    /// <summary>
    /// The invalid package exception.
    /// </summary>
    [Serializable]
    public class InvalidPackageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPackageException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidPackageException(string message)
            : base(message)
        {
        }
    }
}