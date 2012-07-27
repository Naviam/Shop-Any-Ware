// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The profile repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System.Data;

    using TdService.Model.Membership;

    /// <summary>
    /// The profile repository.
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        /// <summary>
        /// Shop any ware db context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ProfileRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Find or add profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to add or find.
        /// </param>
        /// <returns>
        /// The profile.
        /// </returns>
        public Profile FindOrAddProfile(Profile profile)
        {
            return this.context.Profiles.Find(profile.Id)
                ?? this.context.Profiles.Add(profile);
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public void UpdateProfile(Profile profile)
        {
            this.context.Entry(profile).State = EntityState.Modified;
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// Commit changes result.
        /// </returns>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}