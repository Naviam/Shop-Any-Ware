// -----------------------------------------------------------------------
// <copyright file="UserBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// User business rules.
    /// </summary>
    public static class UserBusinessRules
    {
        /// <summary>
        /// This rule ensures that user is valid.
        /// </summary>
        public static readonly BusinessRule UserNotValid =
            new BusinessRule("Email", ErrorCode.UserNotValid.ToString());

        /// <summary>
        /// This rule ensures that email for user is set.
        /// </summary>
        public static readonly BusinessRule EmailRequired =
            new BusinessRule("Email", ErrorCode.UserEmailRequired.ToString());

        /// <summary>
        /// This rule ensures that email for user is within max length.
        /// </summary>
        public static readonly BusinessRule EmailLength =
            new BusinessRule("Email", ErrorCode.UserEmailMaxLength.ToString());

        /// <summary>
        /// This rule ensures that email already exists in repository.
        /// </summary>
        public static readonly BusinessRule EmailExists =
            new BusinessRule("Email", ErrorCode.UserEmailExists.ToString());

        /// <summary>
        /// This rule ensures that password for user is set.
        /// </summary>
        public static readonly BusinessRule PasswordRequired =
            new BusinessRule("Password", ErrorCode.UserPasswordRequired.ToString());

        /// <summary>
        /// This rule ensures that password for user has less chars than max length.
        /// </summary>
        public static readonly BusinessRule PasswordLength =
            new BusinessRule("Password", ErrorCode.UserPasswordMaxLength.ToString());

        /// <summary>
        /// This rule ensures that password for user has more chars than min length.
        /// </summary>
        public static readonly BusinessRule PasswordMinLength =
            new BusinessRule("Password", ErrorCode.UserPasswordMinLength.ToString());

        /// <summary>
        /// This rule ensures that password for user has more chars than min length.
        /// </summary>
        public static readonly BusinessRule NoRolesSpecified =
            new BusinessRule("Roles", ErrorCode.NoRolesSpecified.ToString());
    }
}