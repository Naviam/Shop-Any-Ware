// -----------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Addresses;
    using TdService.Model.Membership;

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
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("DeliveryAddresses").SingleOrDefault(u => u.Email == email);
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
        /// <returns>
        /// The TdService.Model.Addresses.DeliveryAddress.
        /// </returns>
        public DeliveryAddress AddOrUpdateDeliveryAddress(string email, DeliveryAddress address)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("DeliveryAddresses").Include("Profile").Include("Wallet").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new InvalidUserException(ErrorCode.UserNotFound.ToString());
                }

                ////var addressInDb = user.DeliveryAddresses.SingleOrDefault(a => a.Id == address.Id);
                var addressInDb = address.Id == 0 ? null : context.DeliveryAddresses.Find(address.Id);
                if (addressInDb == null)
                {
                    addressInDb = context.DeliveryAddresses.Add(address);
                    context.SaveChanges();

                    if (user.DeliveryAddresses == null)
                    {
                        user.DeliveryAddresses = new List<DeliveryAddress>();
                    }

                    user.DeliveryAddresses.Add(addressInDb);
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    addressInDb.AddressName = address.AddressName;
                    addressInDb.FirstName = address.FirstName;
                    addressInDb.LastName = address.LastName;
                    addressInDb.Phone = address.Phone;
                    addressInDb.Region = address.Region;
                    addressInDb.State = address.State;
                    addressInDb.ZipCode = address.ZipCode;
                    addressInDb.AddressLine1 = address.AddressLine1;
                    addressInDb.AddressLine2 = address.AddressLine2;
                    addressInDb.AddressLine3 = address.AddressLine3;

                    context.Entry(addressInDb).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return addressInDb;
            }
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The TdService.Model.Addresses.DeliveryAddress.
        /// </returns>
        public DeliveryAddress RemoveDeliveryAddress(string email, DeliveryAddress address)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("DeliveryAddresses").Include("Profile").Include("Wallet").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new InvalidUserException(ErrorCode.UserNotFound.ToString());
                }

                var addressToRemove = user.DeliveryAddresses.Find(a => a.Id == address.Id);
                if (addressToRemove != null)
                {
                    user.DeliveryAddresses.Remove(addressToRemove);
                }

                var removedAddress = context.DeliveryAddresses.Remove(addressToRemove);
                context.SaveChanges();
                return removedAddress;
            }
        }
    }
}