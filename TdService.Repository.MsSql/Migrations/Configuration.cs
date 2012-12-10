// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Migrations
{
    using System.Data.Entity.Migrations;

    using TdService.Repository.MsSql;

    /// <summary>
    /// The configuration for database migration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ShopAnyWareSql>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(ShopAnyWareSql context)
        {
            // context.Orders.AddOrUpdate();
            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );

            // context.Users.AddOrUpdate(u => u.Email, new User { Email = "vhatalski@naviam.com" });
        }
    }
}