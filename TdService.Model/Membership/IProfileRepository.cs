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
        /// The profile.
        /// </param>
        /// <returns>
        /// The profile.
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
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// Commit changes result.
        /// </returns>
        int SaveChanges();
    }
}