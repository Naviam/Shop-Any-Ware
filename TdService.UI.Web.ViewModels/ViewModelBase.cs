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
        /// Gets or sets Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Message Type.
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the model errors.
        /// </summary>
        public List<BusinessRule> BrokenRules { get; set; }
    }
}