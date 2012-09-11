// -----------------------------------------------------------------------
// <copyright file="ProfileBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Profile business rules.
    /// </summary>
    public class ProfileBusinessRules
    {
        /// <summary>
        /// This rule ensures that first name is set.
        /// </summary>
        public static readonly BusinessRule FirstNameRequired =
            new BusinessRule("FirstName", ErrorCode.ProfileFirstNameRequired.ToString());

        /// <summary>
        /// This rule ensures that first name is less or equal to 64 chars.
        /// </summary>
        public static readonly BusinessRule FirstNameLength =
            new BusinessRule("FirstName", ErrorCode.ProfileFirstNameMaxLength.ToString());

        /// <summary>
        /// This rule ensures that last name is set.
        /// </summary>
        public static readonly BusinessRule LastNameRequired =
            new BusinessRule("LastName", ErrorCode.ProfileLastNameRequired.ToString());

        /// <summary>
        /// This rule ensures that last name is less or equal to 64 chars.
        /// </summary>
        public static readonly BusinessRule LastNameLength =
            new BusinessRule("LastName", ErrorCode.ProfileLastNameMaxLength.ToString());
    }
}