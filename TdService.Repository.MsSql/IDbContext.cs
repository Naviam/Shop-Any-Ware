// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDbContext.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Interface for ShopAnyWare database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql
{
    using System.Data.Entity;

    using TdService.Model;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;

    /// <summary>
    /// Interface for ShopAnyWare database context.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Gets Items.
        /// </summary>
        IDbSet<Item> Items { get; }

        /// <summary>
        /// Gets Orders.
        /// </summary>
        IDbSet<Order> Orders { get; }

        /// <summary>
        /// Gets Packages.
        /// </summary>
        IDbSet<Package> Packages { get; }

        /// <summary>
        /// Gets Retailers.
        /// </summary>
        IDbSet<Retailer> Retailers { get; }

        /// <summary>
        /// Gets Wallets.
        /// </summary>
        IDbSet<Wallet> Wallets { get; }

        /// <summary>
        /// Gets Transactions.
        /// </summary>
        IDbSet<Transaction> Transactions { get; }

        /// <summary>
        /// Gets Currencies.
        /// </summary>
        IDbSet<Currency> Currencies { get; }

        /// <summary>
        /// Gets Users.
        /// </summary>
        IDbSet<User> Users { get; }

        /// <summary>
        /// Gets Roles.
        /// </summary>
        IDbSet<Role> Roles { get; }

        /// <summary>
        /// Gets Profiles.
        /// </summary>
        IDbSet<Profile> Profiles { get; }

        /// <summary>
        /// Gets DeliveryAddresses.
        /// </summary>
        IDbSet<DeliveryAddress> DeliveryAddresses { get; }

        /// <summary>
        /// Save all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// Result number.
        /// </returns>
        int SaveChanges();
    }
}