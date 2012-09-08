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

    using TdService.Model.Addresses;

    /// <summary>
    /// This class contains methods to work with delivery addresses.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        /// <summary>
        /// Shop any ware db context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public AddressRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

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
            var user = this.context.Users.Include("DeliveryAddresses").SingleOrDefault(u => u.Email == email);
            return user != null ? user.DeliveryAddresses : new List<DeliveryAddress>();
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
            return this.context.DeliveryAddresses.Find(addressId);
        }

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        public DeliveryAddress AddOrUpdateDeliveryAddress(DeliveryAddress address)
        {
            var addressInDb = address.Id == 0 ? null : this.context.DeliveryAddresses.Find(address.Id);
            if (addressInDb == null)
            {
                addressInDb = this.context.DeliveryAddresses.Add(address);
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
            }

            return addressInDb;
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        public DeliveryAddress RemoveDeliveryAddress(DeliveryAddress address)
        {
            return this.context.DeliveryAddresses.Remove(address);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}