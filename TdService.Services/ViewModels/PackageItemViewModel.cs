﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageItemViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package item view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.ViewModels
{
    using TdService.Services.ViewModels.Item;

    /// <summary>
    /// The package item view model.
    /// </summary>
    public class PackageItemViewModel : ItemViewModel
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}