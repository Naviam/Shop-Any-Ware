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
        /// Gets or sets a value indicating whether NotifyOnOrderStatusChanged.
        /// </summary>
        public bool NotifyOnOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyOnPackageStatusChanged.
        /// </summary>
        public bool NotifyOnPackageStatusChanged { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}