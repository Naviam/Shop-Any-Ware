// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   User repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Data.Entity;

    using TdService.Model.Addresses;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;

    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : IUserRepository, IDisposable
    {
        /// <summary>
        /// Shop any ware db context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Attach order.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="orderId">
        /// The order ID.
        /// </param>
        public void AttachOrder(string email, int orderId)
        {
            var user = this.context.Users.SingleOrDefault(user1 => user1.Email == email);
            var order = this.context.Orders.Find(orderId);
            if (user != null)
            {
                if (user.Orders == null)
                {
                    user.Orders = new List<Order> { order };
                }
                else
                {
                    user.Orders.Add(order);
                }
            }
        }

        /// <summary>
        /// Attach package to user.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        public void AttachPackage(string email, int packageId)
        {
            var user = this.context.Users.SingleOrDefault(user1 => user1.Email == email);
            var package = this.context.Packages.Find(packageId);
            if (user != null)
            {
                if (user.Packages == null)
                {
                    user.Packages = new List<Package> { package };
                }
                else
                {
                    user.Packages.Add(package);
                }
            }
        }

        /// <summary>
        /// Attach address to user.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="addressId">
        /// The addresss id to attach.
        /// </param>
        public void AttachAddress(string email, int addressId)
        {
            var user = this.context.Users.SingleOrDefault(user1 => user1.Email == email);
            var address = this.context.DeliveryAddresses.Find(addressId);

            if (user != null)
            {
                if (user.DeliveryAddresses == null)
                {
                    user.DeliveryAddresses = new List<DeliveryAddress> { address };
                }
                else
                {
                    user.DeliveryAddresses.Add(address);
                }
            }
        }

        /// <summary>
        /// Get user by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserByEmail(string email)
        {
            return this.context.Users.Include(u => u.Profile).Include(u => u.Roles).Include(u => u.Wallet).SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Get user with orders by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserWithOrdersByEmail(string email)
        {
            return this.context.Users.Include(u => u.Profile).Include(u => u.Orders).Include(u => u.Roles).SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Get user with packages by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user with packages.
        /// </returns>
        public User GetUserWithPackagesByEmail(string email)
        {
            return this.context.Users.Include(u => u.Profile).Include(u => u.Packages).Include(u => u.Roles).SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Validate user against db.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The boolean value.
        /// </returns>
        public bool ValidateUser(string email, string password)
        {
            var user = this.context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, password, StringComparison.Ordinal) == 0));
            return user != null;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// Created user.
        /// </returns>
        public User CreateUser(User user)
        {
            return this.context.Users.Add(user);
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="user">
        /// The user to update.
        /// </param>
        public void UpdateUser(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove user by user id.
        /// </summary>
        /// <param name="userId">
        /// User ID.
        /// </param>
        public void RemoveUser(int userId)
        {
            var user = this.context.Users.Find(userId);
            if (user != null)
            {
                this.context.Users.Remove(user);
            }
        }

        /// <summary>
        /// Validate user credentials.
        /// </summary>
        /// <param name="user">
        /// The user to validate.
        /// </param>
        /// <returns>
        /// Validation result. True if valid.
        /// </returns>
        public bool ValidateCredentials(User user)
        {
            var userLocal = this.context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, user.Email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, user.Password, StringComparison.Ordinal) == 0));
            return userLocal != null;
        }

        /// <summary>
        /// Gets user list for the specified roleId
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>Tuple of alist of users for the role and a total count</returns>
        public Tuple<List<User>, int> GetUsersInRole(int roleId, int skip, int take)
        {
            var userQuery = this.context.Users.Include(u => u.Profile).Include(u => u.Packages).Include(u => u.Orders).Include(u => u.Roles).Where(
                    u => u.Roles.Select(role => role.Id).Contains(roleId));
            var total = userQuery.Count();
            var pagedList = userQuery.OrderBy(u => u.Id).Skip(skip).Take(take).ToList();
            return new Tuple<List<User>,int>(pagedList,total);
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            var user = this.context.Users.Include(u => u.Profile).Include(u => u.Packages).Include(u => u.Orders).Include(u => u.Roles).SingleOrDefault(u => u.Id.Equals(id));
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Tuple<List<User>, int> GetAllUsers(int skip, int take)
        {
            var userQuery = this.context.Users.Include(u=>u.Profile).Include(u=>u.Packages).Include(u=>u.Orders).Include(u=>u.Roles);
            var total = userQuery.Count();
            var pagedList = userQuery.OrderBy(u=>u.Id).Skip(skip).Take(take).ToList();
            return new Tuple<List<User>, int>(pagedList, total);
        }
    }
}