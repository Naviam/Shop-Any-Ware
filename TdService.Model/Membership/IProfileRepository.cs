// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IProfileRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using Addresses;

    /// <summary>
    /// Profile repository interface.
    /// </summary>
    public interface IProfileRepository 
    {
        Profile GetUserProfile(string username);

        Address GetWarehouseAddress(string username);

        bool ChangePassword(string username, string oldPassword, string newPassword);

        void UpdateUserProfile(string username, Profile profile);
    }
}