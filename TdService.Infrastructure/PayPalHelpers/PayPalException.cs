// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayPalException.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The pay pal exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.PayPalHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PayPal.PayPalAPIInterfaceService.Model;

    /// <summary>
    /// The pay pal exception.
    /// </summary>
    public class PayPalException : Exception
    {
        /// <summary>
        /// The errors.
        /// </summary>
        private readonly List<ErrorType> errors;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayPalException"/> class.
        /// </summary>
        /// <param name="codes">
        /// The codes.
        /// </param>
        public PayPalException(List<ErrorType> codes)
        {
            this.errors = codes;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Join("\n", this.errors.Select(error => error.ShortMessage).ToArray());
            }
        }
    }
}
