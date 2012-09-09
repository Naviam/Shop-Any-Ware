// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressViewModelComparer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The delivery address view model comparer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Features
{
    using System;
    using System.Collections;

    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The delivery address view model comparer.
    /// </summary>
    public class DeliveryAddressViewModelComparer : IComparer
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="first"/> and <paramref name="second"/>, as shown in the following table.Value Meaning Less than zero <paramref name="first"/> is less than <paramref name="second"/>. Zero <paramref name="first"/> equals <paramref name="second"/>. Greater than zero <paramref name="first"/> is greater than <paramref name="second"/>. 
        /// </returns>
        /// <param name="first">The first object to compare. </param><param name="second">The second object to compare. </param><exception cref="T:System.ArgumentException">Neither <paramref name="first"/> nor <paramref name="second"/> implements the <see cref="T:System.IComparable"/> interface.-or- <paramref name="first"/> and <paramref name="second"/> are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
        public int Compare(object first, object second)
        {
            DeliveryAddressViewModel x;
            DeliveryAddressViewModel y;

            if (first is DeliveryAddressViewModel && second is DeliveryAddressViewModel)
            {
                x = first as DeliveryAddressViewModel;
                y = second as DeliveryAddressViewModel;
            }
            else
            {
                throw new ArgumentException("Arguments are of different types and neither one can handle comparisons with the other.");
            }

            ////if (x.Id.CompareTo(y.Id) != 0)
            ////{
            ////    return x.Id.CompareTo(y.Id);
            ////}

            if (string.Compare(x.AddressName, y.AddressName, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.AddressName, y.AddressName, StringComparison.Ordinal);
            }

            if (string.Compare(x.AddressLine1, y.AddressLine1, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.AddressLine1, y.AddressLine1, StringComparison.Ordinal);
            }

            if (string.Compare(x.AddressLine2, y.AddressLine2, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.AddressLine2, y.AddressLine2, StringComparison.Ordinal);
            }

            if (string.Compare(x.AddressLine3, y.AddressLine3, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.AddressLine3, y.AddressLine3, StringComparison.Ordinal);
            }

            if (string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
            }

            if (string.Compare(x.LastName, y.LastName, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
            }

            if (string.Compare(x.State, y.State, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.State, y.State, StringComparison.Ordinal);
            }

            if (string.Compare(x.Country, y.Country, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.Country, y.Country, StringComparison.Ordinal);
            }

            if (string.Compare(x.ZipCode, y.ZipCode, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.ZipCode, y.ZipCode, StringComparison.Ordinal);
            }

            if (string.Compare(x.Region, y.Region, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.Region, y.Region, StringComparison.Ordinal);
            }

            if (string.Compare(x.Phone, y.Phone, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.Phone, y.Phone, StringComparison.Ordinal);
            }

            if (string.Compare(x.City, y.City, StringComparison.Ordinal) != 0)
            {
                return string.Compare(x.City, y.City, StringComparison.Ordinal);
            }

            return 0;
        }
    }
}