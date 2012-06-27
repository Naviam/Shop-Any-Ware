// -----------------------------------------------------------------------
// <copyright file="IAggregateRoot.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    /// <summary>
    /// The aggregate root is a term used in domain-driven design (DDD) to define the entry point into a
    /// logical aggregation of related domain entities. The job of the aggregate root is to ensure that the
    /// aggregation remains in a consistent and valid state. The entity acting as the aggregate root will also
    /// have a corresponding repository to enable data persistence and retrieval.
    /// </summary>
    public interface IAggregateRoot
    {
    }
}