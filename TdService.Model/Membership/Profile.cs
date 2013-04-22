// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Profile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// User profile.
    /// </summary>
    public class Profile : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyOnOrderStatusChanged.
        /// </summary>
        public bool NotifyOnOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyOnPackageStatusChanged.
        /// </summary>
        public bool NotifyOnPackageStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a language of emails sent to user
        /// </summary>
        public string UserCulture { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// The get full name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetFullName()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.FirstName))
            {
                this.AddBrokenRule(ProfileBusinessRules.FirstNameRequired);
            }
            else if (this.FirstName.Length > 21)
            {
                this.AddBrokenRule(ProfileBusinessRules.FirstNameLength);
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                this.AddBrokenRule(ProfileBusinessRules.LastNameRequired);
            }
            else if (this.LastName.Length > 21)
            {
                this.AddBrokenRule(ProfileBusinessRules.LastNameLength);
            }
        }

        public string GetEmailResourceString(string key)
        {
            var ci = string.IsNullOrEmpty(this.UserCulture) ? new CultureInfo("en") : new CultureInfo(this.UserCulture);
            return EmailResources.ResourceManager.GetString(key, ci);
        }

        public string GetTranslatedPackageStatus(string status)
        {
            var ci = string.IsNullOrEmpty(this.UserCulture) ? new CultureInfo("en") : new CultureInfo(this.UserCulture);
            return PackageStatusResources.ResourceManager.GetString(status, ci);
        }
    }
}