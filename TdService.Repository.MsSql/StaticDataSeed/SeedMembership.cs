﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedMembership.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Seed users and roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Balance;
    using TdService.Model.Membership;

    /// <summary>
    /// Seed users and roles.
    /// </summary>
    public static class SeedMembership
    {
        /// <summary>
        /// Populate users.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
        {
            var adminRole = new Role { Name = "Admin", Description = "System Administrator" };
            var shopperRole = new Role { Name = "Shopper", Description = "Main user of the system" };
            var operatorRole = new Role { Name = "Operator", Description = "Person who process orders" };
            var consultantRole = new Role { Name = "Consultant", Description = "Person who help user to solve service issues" };
            context.Roles.Add(adminRole);
            context.Roles.Add(shopperRole);
            context.Roles.Add(operatorRole);
            context.Roles.Add(consultantRole);

            context.SaveChanges();

            // vitali
            var profile = new Profile
            {
                FirstName = "Vitali",
                LastName = "Hatalski",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profile);
            context.SaveChanges();

            var user = new User
            {
                Email = "vhatalski@naviam.com",
                Password = "ruinruin",
                Profile = profile,
                Roles = new List<Role> { adminRole, shopperRole, operatorRole },
                Wallet = new Wallet { Amount = 1003.23m }
            };
            context.Users.Add(user);
            context.SaveChanges();

            // oleg
            var profileOleg = new Profile
            {
                FirstName = "Oleg",
                LastName = "Voronin",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profileOleg);
            context.SaveChanges();

            var userOleg = new User
            {
                Email = "tdservice@mail.ru",
                Password = "1111111",
                Roles = new List<Role> { adminRole },
                Wallet = new Wallet { Amount = 988.00m },
                Profile = profileOleg,
                ActivationCode = Guid.NewGuid()
            };
            context.Users.Add(userOleg);
            context.SaveChanges();

            // shopper
            var profileShopper = new Profile
            {
                FirstName = "Shopper First name",
                LastName = "Shopper Last name",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profileShopper);
            context.SaveChanges();

            var shopper = new User
            {
                Email = "v.hatalski@gmail.com",
                Password = "1111111111",
                Profile = profileShopper,
                Roles = new List<Role> { shopperRole },
                Wallet = new Wallet { Amount = 88.00m },
                ActivationCode = Guid.NewGuid()
            };
            context.Users.Add(shopper);
            context.SaveChanges();

            // operator
            var profileOperator = new Profile
            {
                FirstName = "Operator First name",
                LastName = "Operator Last name",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profileOperator);
            context.SaveChanges();

            var operatorUser = new User
            {
                Email = "operator@shopanyware.ru",
                Password = "1111111111",
                Profile = profileOperator,
                Roles = new List<Role> { operatorRole },
                Wallet = new Wallet { Amount = 0.00m },
                ActivationCode = Guid.NewGuid()
            };
            context.Users.Add(operatorUser);
            context.SaveChanges();

            // consultant
            var profileConsultant = new Profile
            {
                FirstName = "Consultant First name",
                LastName = "Consultant Last name",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profileConsultant);
            context.SaveChanges();

            var consultant = new User
            {
                Email = "consultant@shopanyware.ru",
                Password = "1111111111",
                Profile = profileConsultant,
                Roles = new List<Role> { consultantRole },
                Wallet = new Wallet { Amount = 0.00m },
                ActivationCode = Guid.NewGuid()
            };
            context.Users.Add(consultant);
            context.SaveChanges();


            // consultant
            var profileKotg = new Profile
            {
                FirstName = "Kotg First name",
                LastName = "Kotg Last name",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profileKotg);
            context.SaveChanges();
            var kotg = new User
            {
                Email = "kotg@bk.ru",
                Password = "2320244",
                Profile = profileKotg,
                Roles = new List<Role> { adminRole, shopperRole, operatorRole },
                Wallet = new Wallet { Amount = 0 }
            };
            context.Users.Add(kotg);
            context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                var s = i.ToString();
                var bulkProfile = new Profile
                {
                    FirstName = "First Name "+s,
                    LastName = "Last name " + s,
                    NotifyOnOrderStatusChanged = true,
                    NotifyOnPackageStatusChanged = true
                };
                context.Profiles.Add(bulkProfile);
                context.SaveChanges();

                var bulkUser = new User
                {
                    Email = string.Format("user{0}@gmail.com",s),
                    Password = "111111",
                    Profile = bulkProfile,
                    Roles = new List<Role> {shopperRole},
                    Wallet = new Wallet { Amount = 0 }
                };
                context.Users.Add(bulkUser);
                context.SaveChanges();
            }
        }
    }
}