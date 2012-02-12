// -----------------------------------------------------------------------
// <copyright file="SignInRequest.cs" company="TdService">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.AppService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SignInRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }
    }
}
