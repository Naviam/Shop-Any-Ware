// -----------------------------------------------------------------------
// <copyright file="UserBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// User business rules.
    /// </summary>
    public class UserBusinessRules
    {
        /// <summary>
        /// This rule ensures that email for user is set.
        /// </summary>
        public static readonly BusinessRule EmailRequired =
            new BusinessRule("Email", BusinessRules.User_EmailRequired);
    }
}