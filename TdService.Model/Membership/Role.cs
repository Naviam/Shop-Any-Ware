// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Role type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;
    using System.Collections.Generic;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// User role.
    /// </summary>
    public class Role : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not implemented yet
        /// </exception>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.AddBrokenRule(RoleBusinessRules.NameRequired);
            }
            else if (this.Name.Length > 64)
            {
                this.AddBrokenRule(RoleBusinessRules.NameLength);
            }

            if (!string.IsNullOrEmpty(this.Description) && this.Description.Length > 1024)
            {
                this.AddBrokenRule(RoleBusinessRules.DescriptionLength);
            }
        }
    }
}