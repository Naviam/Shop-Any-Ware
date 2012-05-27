// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationRule.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   User notification rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Notification
{
    using System;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// User notification rules.
    /// </summary>
    public class NotificationRule : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets a value indicating whether NotifyOrderStatusChanged.
        /// </summary>
        public bool NotifyOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyParcelStatusChanged.
        /// </summary>
        public bool NotifyParcelStatusChanged { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}