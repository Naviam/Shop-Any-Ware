// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainErrors.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The domain errors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The domain errors.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum DomainErrors
    {
        UserNotFound,
        ProfileNotFound
    }
}