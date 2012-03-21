// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IPackageRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using System.Collections.Generic;
    using Domain;
    using Orders;

    /// <summary>
    /// The interface for package repository.
    /// </summary>
    public interface IPackageRepository 
    {
        void AddOrdersToParcel(int parcelId, IEnumerable<Order> orders);

        void RemoveParcel(int parcelId);

        IEnumerable<Parcel> GetUserParcels(string username, object sortDirection, string sortExpression, string filterExpression, int pageSize);

        IEnumerable<Parcel> GetAllParcels(object sortDirection, string sortExpression, string filterExpression, int pageSize = 20);

        Parcel GetParcelDetails(int parcelId);

        void UpdateParcel(Parcel parcel);

        void UpdateParcelStatus(int parcelId, ParcelStatus newStatus);

        /// <summary>
        /// Adds new parcel and returns parcel id
        /// </summary>
        int AddParcel(string username, Parcel parcel);
    }
}