// -----------------------------------------------------------------------
// <copyright file="ResponseBase.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Messaging
{
    using System.Collections.Generic;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The base class for service response.
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Gets or sets Message Type.
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Error Code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the broken rules.
        /// </summary>
        public List<BusinessRule> BrokenRules { get; set; }
    }
}