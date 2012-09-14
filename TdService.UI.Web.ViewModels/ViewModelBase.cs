// -----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels
{
    using System.Collections.Generic;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Base class for view models.
    /// </summary>
    public class ViewModelBase
    {
        /// <summary>
        /// The message.
        /// </summary>
        private string message;

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.message) ? 
                    (string.IsNullOrWhiteSpace(this.ErrorCode) ? this.message : Resources.ErrorCodeResources.ResourceManager.GetString(this.ErrorCode))
                    : this.message;
            }

            set
            {
                this.message = value;
            }
        }

        /// <summary>
        /// Gets or sets Message Type.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the model errors.
        /// </summary>
        public List<BusinessRule> BrokenRules { get; set; }
    }
}