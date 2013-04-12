// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProfileRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Profile repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    /// <summary>
    /// Profile repository interface.
    /// </summary>
    public interface IProfileRepository
    {
        /// <summary>
        /// Find or add profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to add or find.
        /// </param>
        /// <returns>
        /// The profile result.
        /// </returns>
        Profile FindOrAddProfile(Profile profile);

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        void UpdateProfile(Profile profile);

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        /// <returns>
        /// Commit changes result.
        /// </returns>
        int SaveChanges();
    }
}