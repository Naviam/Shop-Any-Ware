// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

    /// <summary>
    /// This is a base class for address information.
    /// </summary>
    public class Address
	{
        /// <summary>
        /// Gets or sets AddressName.
        /// </summary>
        public virtual string AddressName { get; set; }

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        public virtual int Zip { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// Gets or sets Region.
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Gets or sets Address1.
        /// </summary>
        public virtual string Address1 { get; set; }

        /// <summary>
        /// Gets or sets Address2.
        /// </summary>
        public virtual string Address2 { get; set; }

        /// <summary>
        /// Gets or sets Address3.
        /// </summary>
        public virtual string Address3 { get; set; }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        public virtual string Phone { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public virtual int Id { get; set; }
    }
}