// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Package.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Package type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using System;
    using System.Collections.Generic;

    using Addresses;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Items;
    using TdService.Model.Shipping;

    /// <summary>
    /// Package that user creates to send to home address.
    /// </summary>
    public class Package : EntityBase<int>
    {
        /// <summary>
        /// The package state.
        /// </summary>
        private readonly IPackageState packageState;

        /// <summary>
        /// Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        public Package()
        {
            this.packageState = new PackageNewState();
            this.Status = PackageStatus.New;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets Dispatched Date.
        /// </summary>
        public DateTime? DispatchedDate { get; set; }

        /// <summary>
        /// Gets or sets Delivered Date.
        /// </summary>
        public DateTime? DeliveredDate { get; set; }

        /// <summary>
        /// Gets or sets Delivery Address.
        /// </summary>
        public DeliveryAddress DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets DispatchMethod.
        /// </summary>
        public DispatchMethod DispatchMethod { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets a value indicating whether package can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return this.packageState.CanBeModified;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return this.packageState.CanItemsBeModified;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be sent.
        /// </summary>
        public bool CanBeSent
        {
            get
            {
                return this.packageState.CanBeSent;
            }
        }


        /// <summary>
        /// Gets a value indicating whether package can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return this.packageState.CanBeRemoved;
            }
        }

        /// <summary>
        /// Gets a value indicating whether package can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get
            {
                return this.packageState.CanBeDisposed;
            }
        }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.AddBrokenRule(PackageBusinessRules.NameRequired);
            }
            else if (this.Name.Length > 64)
            {
                this.AddBrokenRule(PackageBusinessRules.NameLength);
            }
        }
    }
}