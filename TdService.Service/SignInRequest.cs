﻿// -----------------------------------------------------------------------
// <copyright file="SignInRequest.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Service
{
    /// <summary>
    /// This class describes request parameters for sign in action.
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