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

    /// <summary>
    /// The country.
    /// </summary>
    public class Country : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The validate.
        /// </summary>
        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
