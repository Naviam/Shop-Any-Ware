// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This class describes user in the system
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Addresses;

    using Packages;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Balance;
    using TdService.Model.Orders;

    /// <summary>
    /// This class describes user in the system
    /// </summary>
    public class User : EntityBase<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Orders = new List<Order>();
            this.Packages = new List<Package>();
            this.Wallet = new Wallet();
            this.DeliveryAddresses = new List<DeliveryAddress>();
            this.Roles = new List<Role>();
            this.Profile = new Profile();
        }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the activation code.
        /// </summary>
        public Guid ActivationCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether activated.
        /// </summary>
        public bool Activated { get; set; }

        /// <summary>
        /// Gets or sets LastAccessDate 
        /// </summary>
        public DateTime? LastAccessDate { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets Profile.
        /// </summary>
        public Profile Profile { get; set; }
        
        /// <summary>
        /// Gets or sets DeliveryAddresses.
        /// </summary>
        public List<DeliveryAddress> DeliveryAddresses { get; set; }

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets Wallet.
        /// </summary>
        public Wallet Wallet { get; set; }


        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets Packages.
        /// </summary>
        public List<Package> Packages { get; set; }

        /// <summary>
        /// Checks whether user has order with specified ID.
        /// </summary>
        /// <param name="orderId">
        /// The order ID to look for.
        /// </param>
        /// <returns>
        /// The order.
        /// </returns>
        public Order GetOrderById(int orderId)
        {
            return this.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        /// <summary>
        /// Get package by id.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The TdService.Model.Packages.Package.
        /// </returns>
        public Package GetPackageById(int packageId)
        {
            return this.Packages.FirstOrDefault(p => p.Id == packageId);
        }

        /// <summary>
        /// Get the most recent user orders 
        /// (when order is not yet received or older than 30 days from received date).
        /// </summary>
        /// <returns>
        /// Collection of the most recent user orders.
        /// </returns>
        public List<Order> GetRecentOrders()
        {
            var orders = this.Orders;
            if (orders != null)
            {
                var result = from o in orders
                             where
                                 (o.Status == OrderStatus.New || o.Status == OrderStatus.Received
                                 || o.Status == OrderStatus.ReturnRequested)
                             orderby o.CreatedDate descending
                             select o;
                return result.ToList();
            }

            this.Orders = new List<Order>();
            return this.Orders;
        }

        /// <summary>
        /// Get recent packages.
        /// </summary>
        /// <returns>
        /// Collection of recent packages.
        /// </returns>
        public List<Package> GetRecentPackages()
        {
            var packages = this.Packages;
            if (packages != null)
            {
                return packages.Where(
                    p => !p.DeliveredDate.HasValue
                             || p.DeliveredDate.Value > DateTime.UtcNow.AddDays(-30)).ToList();
            }

            this.Packages = new List<Package>();
            return this.Packages;
        }

        /// <summary>
        /// The get history packages.
        /// </summary>
        /// <returns>
        /// The list of <see cref="Package"/>.
        /// </returns>
        public List<Package> GetHistoryPackages()
        {
            var packages = this.Packages;
            if (packages != null)
            {
                var result = from o in packages
                             where o.Status == PackageStatus.Delivered
                             orderby o.DeliveredDate descending
                             select o;
                return result.ToList();
            }

            this.Packages = new List<Package>();
            return this.Packages;
        }

        /// <summary>
        /// The add package.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public void AddPackage(Package package)
        {
            if (this.Roles.Exists(r => r.Name == StandardRole.Shopper.ToString()))
            {
                this.Packages.Add(package);
                return;
            }

            throw new InvalidOrderException(ErrorCode.PackageCannotBeAddedByYou.ToString());
        }

        /// <summary>
        /// Add new order to user.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public void AddOrder(Order order)
        {
            if (this.Roles.Exists(r => r.Name == StandardRole.Shopper.ToString()))
            {
                this.Orders.Add(order);
                return;
            }

            throw new InvalidOrderException(ErrorCode.OrderCannotBeAddedByYou.ToString());
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order RemoveOrder(int orderId)
        {
            var order = this.GetOrderById(orderId);
            if (order != null)
            {
                if (order.CanBeRemoved 
                    && this.Roles.Exists(r => r.Name == StandardRole.Shopper.ToString() || r.Name == StandardRole.Admin.ToString()))
                {
                    this.Orders.Remove(order);
                    return order;
                }

                throw new InvalidOrderException(ErrorCode.OrderCannotBeRemoved.ToString());
            }

            throw new InvalidOrderException(ErrorCode.OrderNotFoundForUser.ToString());
        }

        /// <summary>
        /// The remove package.
        /// </summary>
        /// <param name="id">
        /// The package id.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool RemovePackage(int id)
        {
            var package = this.GetPackageById(id);
            if (package != null)
            {
                if (package.CanBeRemoved)
                {
                    this.Packages.Remove(package);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RemoveUserFromRole(int roleId)
        {
            var role = this.Roles.SingleOrDefault(r => r.Id.Equals(roleId));
            if (role != null)
            {
                this.Roles.Remove(role);
                return true;
            }

            throw new MemberShipException(ErrorCode.UserIsNotInRole.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddUserToRole(Role role)
        {
            if (!this.Roles.Select(r => r.Id).Contains(role.Id))
            {
                
                this.Roles.Add(role);
                return true;
            }
            throw new MemberShipException(ErrorCode.UserIsAlreadyInRole.ToString());
        }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                this.AddBrokenRule(UserBusinessRules.EmailRequired);
            }
            else if (this.Email.Length > 256)
            {
                this.AddBrokenRule(UserBusinessRules.EmailLength);
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.AddBrokenRule(UserBusinessRules.PasswordRequired);
            }
            else if (this.Password.Length > 21)
            {
                this.AddBrokenRule(UserBusinessRules.PasswordLength);
            }
            else if (this.Password.Length < 7)
            {
                this.AddBrokenRule(UserBusinessRules.PasswordMinLength);
            }
        }
    }
}