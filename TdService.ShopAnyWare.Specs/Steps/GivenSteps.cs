// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GivenSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The given steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using AutoMapper;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Repository.MsSql;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// The given steps.
    /// </summary>
    [Binding]
    public class GivenSteps
    {
        /// <summary>
        /// The given there is account with password in role with full name and.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        [Given(@"there is '(.*)' account with '(.*)' password in role '(.*)' with fullname '(.*)' and '(.*)'")]
        public void GivenThereIsAccountWithPasswordInRoleWithFullnameAnd(
            string email, string password, string roleName, string firstName, string lastName)
        {
            Mapper.AssertConfigurationIsValid();
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").Include("Wallet").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }

                var role = context.Roles.SingleOrDefault(r => r.Name == roleName)
                               ?? context.Roles.Add(new Role { Name = roleName });

                var profile = new Profile { FirstName = firstName, LastName = lastName };
                context.Profiles.Add(profile);

                user = new User
                {
                    Email = email,
                    Password = password,
                    Profile = profile,
                    Wallet = new Wallet { Amount = 0m },
                    Roles = new List<Role> { role }
                };

                context.Users.Add(user);
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given i have not been authenticated yet.
        /// </summary>
        [Given(@"I have not been authenticated yet")]
        public void GivenIHaveNotBeenAuthenticatedYet()
        {
            var formsAuthentication = new FakeFormsAuthentication();
            ScenarioContext.Current.Set(formsAuthentication);
        }

        /// <summary>
        /// The given i am authenticated as.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        [Given(@"I am authenticated as '(.*)'")]
        public void GivenIAmAuthenticatedAs(string email)
        {
            var formsAuthentication = new FakeFormsAuthentication();
            formsAuthentication.SetAuthenticationToken(email, true);
            ScenarioContext.Current.Set(formsAuthentication);
        }

        /// <summary>
        /// The given i have the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have the following delivery addresses")]
        public void GivenIHaveTheFollowingDeliveryAddresses(Table table)
        {
            var addresses = table.CreateSet<DeliveryAddress>();
            var user = ScenarioContext.Current.Get<User>();
            using (var context = new ShopAnyWareSql())
            {
                context.Wallets.Attach(user.Wallet);
                context.Profiles.Attach(user.Profile);
                context.Users.Attach(user);
                if (user.DeliveryAddresses == null)
                {
                    user.DeliveryAddresses = new List<DeliveryAddress>();
                }

                var addedAddresses = addresses.Select(deliveryAddress => context.DeliveryAddresses.Add(deliveryAddress)).ToList();
                context.SaveChanges();

                user.DeliveryAddresses.AddRange(addedAddresses.ToList());
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given i have the following orders.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have the following orders")]
        public void GivenIHaveTheFollowingOrders(Table table)
        {
            var user = ScenarioContext.Current.Get<User>();
            using (var context = new ShopAnyWareSql())
            {
                var orders = table.CreateSet<Order>().Select(o => { context.Entry<Order>(o).State = EntityState.Added; return o; });
                if (user.Orders == null)
                {
                    user.Orders = new List<Order>();
                }

                user.Orders.AddRange(orders);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given i have the following packages.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have the following packages")]
        public void GivenIHaveTheFollowingPackages(Table table)
        {
            var packages = table.CreateSet<Package>();
            var user = ScenarioContext.Current.Get<User>();
            using (var context = new ShopAnyWareSql())
            {

                if (user.Packages == null)
                {
                    user.Packages = new List<Package>();
                }

                var addedPackages = packages.Select(p =>
                    {
                        p.CreatedDate = DateTime.Now;
                        p.Dimensions = new Dimensions();
                        return context.Packages.Add(p);
                    });

                user.Packages.AddRange(addedPackages);
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given there are following orders in database.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"there are following orders in database")]
        public void GivenThereAreFollowingOrdersInDatabase(Table table)
        {
            var orders = this.OrdersTransform(table);
            using (var context = new ShopAnyWareSql())
            {
                var addedOrders = orders.Select(order => context.Orders.Add(order)).ToList();
                context.SaveChanges();
                ScenarioContext.Current.Set(addedOrders);
            }
        }

        /// <summary>
        /// The given there are following items for order in database.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"there are following items for order '(.*)' in database")]
        public void GivenThereAreFollowingItemsForOrderInDatabase(string orderNumber, Table table)
        {
            var user = ScenarioContext.Current.Get<User>();
            var orderId = user.Orders.SingleOrDefault(o => o.OrderNumber.Equals(orderNumber)).Id;

            var items = table.CreateSet<Item>().Select(i => { i.Dimensions = new Dimensions(); i.Weight = new Weight(); return i; });
            ScenarioContext.Current.Set(orderId, "OrderId");
            using (var context = new ShopAnyWareSql())
            {
                var order = context.Orders.Find(orderId);
                if (order.Items == null)
                {
                    order.Items = new List<Item>();
                }

                order.Items.AddRange(items);
                context.Orders.Attach(order);
                context.SaveChanges();
                ScenarioContext.Current.Set(order.Items);
            }
        }

        [Given(@"there are following items for package '(.*)' in database")]
        public void GivenThereAreFollowingItemsForPackageInDatabase(string  packageName, Table table)
        {
            var user = ScenarioContext.Current.Get<User>();
            var packageId = user.Packages.SingleOrDefault(p => p.Name.Equals(packageName)).Id;
            
            ScenarioContext.Current.Set(packageId, "PackageId");
            var items = table.CreateSet<Item>().Select(i => { i.Dimensions = new Dimensions(); i.Weight = new Weight(); return i; }); ;
            using (var context = new ShopAnyWareSql())
            {
                var package = context.Packages.Find(packageId);
                if (package.Items == null)
                {
                    package.Items = new List<Item>();
                }
                context.Packages.Attach(package);
                package.Items.AddRange(items);
                context.SaveChanges();
                ScenarioContext.Current.Set(package.Items);
            }
        }


        /// <summary>
        /// The orders transform.
        /// </summary>
        /// <param name="ordersTable">
        /// The orders table.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TdService.Model.Orders.Order].
        /// </returns>
        [StepArgumentTransformation]
        public IEnumerable<Order> OrdersTransform(Table ordersTable)
        {
            return from tableRow in ordersTable.Rows
                   let retailer = new Retailer(tableRow["Retailer"])
                   let orderNumber = tableRow["Order Number"]
                   let trackingNumber = tableRow["Tracking Number"]
                   let statusText = tableRow["Status"]
                   let status = (OrderStatus)Enum.Parse(typeof(OrderStatus), statusText)
                   select new Order(status)
                   {
                       Retailer = retailer,
                       OrderNumber = orderNumber,
                       TrackingNumber = trackingNumber,
                       CreatedDate = DateTime.UtcNow
                   };
        }
    }
}