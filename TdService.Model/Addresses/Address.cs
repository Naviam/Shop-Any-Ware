// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using System;
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// This is a base class for address information.
    /// </summary>
    public class Address : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets AddressName.
        /// </summary>
        public string AddressName { get; set; }

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        public int Zip { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Address1.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets Address2.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets Address3.
        /// </summary>
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate object.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}