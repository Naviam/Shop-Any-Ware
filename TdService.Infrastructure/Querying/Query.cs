// -----------------------------------------------------------------------
// <copyright file="Query.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Querying
{
    using System.Collections.Generic;

    /// <summary>
    /// Query class.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        public Query()
        {
            this.SubQueries = new List<Query>();
            this.Criteria = new List<Criterion>();
        }

        /// <summary>
        /// Gets Criteria.
        /// </summary>
        public IList<Criterion> Criteria { get; private set; }

        /// <summary>
        /// Gets SubQueries.
        /// </summary>
        public IList<Query> SubQueries { get; private set; }

        /// <summary>
        /// Gets or sets QueryOperator.
        /// </summary>
        public QueryOperator QueryOperator { get; set; }

        /// <summary>
        /// Gets or sets OrderByProperty.
        /// </summary>
        public OrderByClause OrderByProperty { get; set; }

        /// <summary>
        /// Add sub query.
        /// </summary>
        /// <param name="subQuery">
        /// The sub query.
        /// </param>
        public void AddSubQuery(Query subQuery)
        {
            this.SubQueries.Add(subQuery);
        }

        /// <summary>
        /// Add criterion.
        /// </summary>
        /// <param name="criterion">
        /// The criterion.
        /// </param>
        public void Add(Criterion criterion)
        {
            this.Criteria.Add(criterion);
        }
    }
}