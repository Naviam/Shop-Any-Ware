// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopAnyWareRoleProvider.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The role provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Providers
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Web.Security;

    using TdService.Model.Membership;
    using TdService.Repository.MsSql;

    /// <summary>
    /// The role provider.
    /// </summary>
    public class ShopAnyWareRoleProvider : RoleProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopAnyWareRoleProvider"/> class.
        /// </summary>
        public ShopAnyWareRoleProvider()
        {
        }

        /// <summary>
        /// Gets or sets the name of the application to store and retrieve role information for.
        /// </summary>
        /// <returns>
        /// The name of the application to store and retrieve role information for.
        /// </returns>
        public override string ApplicationName { get; set; }

        /// <summary>
        /// Initialize role provider.
        /// </summary>
        /// <param name="name">
        /// The provider name.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (string.IsNullOrEmpty(name))
            {
                name = "ShopAnyWareRoleProvider";
            }

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Shop Any Ware Role Provider");
            }

            base.Initialize(name, config);

            foreach (string key in config.Keys)
            {
                if (string.Compare(key, "applicationname", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    this.ApplicationName = config[key];
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the specified user is in the specified role for the configured applicationName.
        /// </summary>
        /// <returns>
        /// true if the specified user is in the specified role for the configured applicationName; otherwise, false.
        /// </returns>
        /// <param name="username">The user name to search for.</param><param name="roleName">The role to search in.</param>
        public override bool IsUserInRole(string username, string roleName)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user =
                    context.Users.Include("Profile").Include("Roles").SingleOrDefault(u => u.Email == username);
                return user != null && user.Roles.Any(r => r.Name == roleName);
            }
        }

        /// <summary>
        /// Gets a list of the roles that a specified user is in for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles that the specified user is in for the configured applicationName.
        /// </returns>
        /// <param name="username">The user to return a list of roles for.</param>
        public override string[] GetRolesForUser(string username)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").Include("Roles").SingleOrDefault(u => u.Email == username);
                if (user != null)
                {
                    return user.Roles.Select(r => r.Name).ToArray();
                }
            }

            return new string[] { };
        }

        /// <summary>
        /// Adds a new role to the data source for the configured applicationName.
        /// </summary>
        /// <param name="roleName">The name of the role to create.</param>
        public override void CreateRole(string roleName)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = new Role { Name = roleName, Description = string.Empty };
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a role from the data source for the configured applicationName.
        /// </summary>
        /// <returns>
        /// true if the role was successfully deleted; otherwise, false.
        /// </returns>
        /// <param name="roleName">The name of the role to delete.</param><param name="throwOnPopulatedRole">If true, throw an exception if <paramref name="roleName"/> has one or more members and do not delete <paramref name="roleName"/>.</param>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => r.Name == roleName);
                context.Roles.Remove(role);
                context.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Gets a value indicating whether the specified role name already exists in the role data source for the configured applicationName.
        /// </summary>
        /// <returns>
        /// true if the role name already exists in the data source for the configured applicationName; otherwise, false.
        /// </returns>
        /// <param name="roleName">The name of the role to search for in the data source.</param>
        public override bool RoleExists(string roleName)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => r.Name == roleName);
                return role != null;
            }
        }

        /// <summary>
        /// Adds the specified user names to the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be added to the specified roles. </param><param name="roleNames">A string array of the role names to add the specified user names to.</param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified user names from the specified roles for the configured applicationName.
        /// </summary>
        /// <param name="usernames">A string array of user names to be removed from the specified roles. </param><param name="roleNames">A string array of role names to remove the specified user names from.</param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of users in the specified role for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the users who are members of the specified role for the configured applicationName.
        /// </returns>
        /// <param name="roleName">The name of the role to get the list of users for.</param>
        public override string[] GetUsersInRole(string roleName)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    var users = from user in role.Users select user.Email;
                    return users.ToArray();
                }
            }
            return new string[] { };
        }

        /// <summary>
        /// Gets a list of all the roles for the configured applicationName.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the roles stored in the data source for the configured applicationName.
        /// </returns>
        public override string[] GetAllRoles()
        {
            using (var context = new ShopAnyWareSql())
            {
                var roles = context.Roles.ToList();
                return roles.Select(role => role.Name).ToArray();
            }
        }

        /// <summary>
        /// Gets an array of user names in a role where the user name contains the specified user name to match.
        /// </summary>
        /// <returns>
        /// A string array containing the names of all the users where the user name matches <paramref name="usernameToMatch"/> and the user is a member of the specified role.
        /// </returns>
        /// <param name="roleName">The role to search in.</param><param name="usernameToMatch">The user name to search for.</param>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => r.Name == roleName);
                if (role != null)
                {
                    var users = from user in role.Users where user.Email.Contains(usernameToMatch) select user.Email;
                    return users.ToArray();
                }
            }

            return new string[] { };
        }
    }
}