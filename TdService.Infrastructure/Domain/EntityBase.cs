// -----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Because all entities will share the same validation mechanism, we create a Layer Super type
    /// that all domain entities will inherit from and that will provide the
    /// infrastructure for checking domain validity..
    /// </summary>
    /// <typeparam name="TId">
    /// Any type of object.
    /// </typeparam>
    public abstract class EntityBase<TId>
    {
        /// <summary>
        /// Collection of broken rules.
        /// </summary>
        private readonly List<BusinessRule> brokenRules = new List<BusinessRule>();

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public TId Id { get; set; }

        ////public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        ////{
        ////    if ((object)entity1 == null && (object)entity2 == null)
        ////    {
        ////        return true;
        ////    }

        ////    if ((object)entity1 == null || (object)entity2 == null)
        ////    {
        ////        return false;
        ////    }

        ////    return entity1.GetHashCode().Equals(entity2.GetHashCode());
        ////    //return entity1.Id.ToString() == entity2.Id.ToString();
        ////}

        ////public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        ////{
        ////    return !(entity1 == entity2);
        ////}

        /// <summary>
        /// Get the collection of broken rules.
        /// </summary>
        /// <returns>
        /// Collection of broken rules.
        /// </returns>
        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            this.brokenRules.Clear();
            this.Validate();
            return this.brokenRules;
        }

        ////public override bool Equals(object entity)
        ////{
        ////    return entity != null
        ////           && entity is EntityBase<TId>
        ////           && this == (EntityBase<TId>)entity;
        ////}

        ////public override int GetHashCode()
        ////{
        ////    return this.Id.GetHashCode();
        ////}

        /// <summary>
        /// Add broken rule to collection.
        /// </summary>
        /// <param name="businessRule">
        /// The business rule.
        /// </param>
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            this.brokenRules.Add(businessRule);
        }

        /// <summary>
        /// Validate against rules method.
        /// </summary>
        protected abstract void Validate();
    }
}