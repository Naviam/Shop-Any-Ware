// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeProfileRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeProfileRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using TdService.Model.Membership;

    /// <summary>
    /// The fake profile repository.
    /// </summary>
    public class FakeProfileRepository : IProfileRepository
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
        public Profile FindOrAddProfile(Profile profile)
        {
            return null;
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public void UpdateProfile(Profile profile)
        {
        }

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        /// <returns>
        /// Commit changes result.
        /// </returns>
        public int SaveChanges()
        {
            return 0;
        }
    }
}
