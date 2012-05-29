// -----------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TdService.Model.Addresses;

    /// <summary>
    /// This class contains methods to work with delivery addresses.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        /// <summary>
        /// Get the list of user's addresses.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// Collection of user's addresses.
        /// </returns>
        public List<DeliveryAddress> GetDeliveryAddresses(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == email);
                return user != null ? user.DeliveryAddresses : new List<DeliveryAddress>();
            }
        }

        /// <summary>
        /// Get warehouse address in U.S. for user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// User's warehouse address in U.S.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        public WarehouseAddress GetWarehouseAddress(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get user's delivery address details.
        /// </summary>
        /// <param name="addressId">
        /// The address id.
        /// </param>
        /// <returns>
        /// User's delivery address details.
        /// </returns>
        public DeliveryAddress GetDeliveryAddressDetails(int addressId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.DeliveryAddresses.Find(addressId);
            }
        }

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        public void AddOrUpdateDeliveryAddress(string email, DeliveryAddress address)
        {
            using (var context = new ShopAnyWareSql())
            {
                var deliveryAddress = context.DeliveryAddresses.Find(address.Id);
                if (deliveryAddress == null)
                {
                    context.DeliveryAddresses.Add(address);
                }

                var user = (from u in context.Users where u.Email == email select u).SingleOrDefault();
                if (user != null)
                {
                    user.DeliveryAddresses.Add(address);
                }
                else
                {
                    throw new Exception("The provided email was not found.");
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        public void RemoveDeliveryAddress(DeliveryAddress address)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.DeliveryAddresses.Remove(address);
                context.SaveChanges();
            }
        }
    }
}