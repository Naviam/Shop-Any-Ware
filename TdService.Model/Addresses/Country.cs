// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Country.cs" company="Naviam">
//   Vitali Hatalski. 2013.
// </copyright>
// <summary>
//   Defines the Country type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// The country.
    /// </summary>
    public class Country : EntityBase<int>
    {
        /// <summary>
        /// Gets the translated name.
        /// </summary>
        public string TranslatedName
        {
            get
            {
                var translated = Countries.ResourceManager.GetString(this.Code);
                if (string.IsNullOrEmpty(translated))
                {
                    return string.Empty;
                }

                return translated;
            }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the default name.
        /// </summary>
        public string DefaultName { get; set; }

        /// <summary>
        /// The validate.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}
