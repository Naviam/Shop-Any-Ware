// -----------------------------------------------------------------------
// <copyright file="OrderByClause.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Querying
{
    /// <summary>
    /// Order by clause.
    /// </summary>
    public class OrderByClause
    {
        /// <summary>
        /// Gets or sets PropertyName.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Desc.
        /// </summary>
        public bool Desc { get; set; }
    }
}