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
    public static class UserBusinessRules
    {
        /// <summary>
        /// This rule ensures that email for user is set.
        /// </summary>
        public static readonly BusinessRule EmailRequired =
            new BusinessRule("Email", BusinessRules.User_EmailRequired);

        /// <summary>
        /// This rule ensures that email for user is within max length.
        /// </summary>
        public static readonly BusinessRule EmailLength =
            new BusinessRule("Email", BusinessRules.User_EmailLength);

        /// <summary>
        /// This rule ensures that password for user is set.
        /// </summary>
        public static readonly BusinessRule PasswordRequired =
            new BusinessRule("Password", BusinessRules.User_PasswordRequired);

        /// <summary>
        /// This rule ensures that password for user is within max length.
        /// </summary>
        public static readonly BusinessRule PasswordLength =
            new BusinessRule("Password", BusinessRules.User_PasswordLength);
    }
}