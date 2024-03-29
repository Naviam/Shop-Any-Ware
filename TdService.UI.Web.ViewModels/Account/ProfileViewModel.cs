﻿// -----------------------------------------------------------------------
// <copyright file="ProfileViewModel.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation.Attributes;

    /// <summary>
    /// This is the profile model for web form.
    /// </summary>
    [Validator(typeof(ProfileViewModelValidator))]
    public class ProfileViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Notify On Order Status Changed.
        /// </summary>
        public bool NotifyOnOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Notify On Package Status Changed.
        /// </summary>
        public bool NotifyOnPackageStatusChanged { get; set; }
    }
}