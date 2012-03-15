// -----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Because all entities will share the same validation mechanism, we create a Layer Supertype
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

        /// <summary>
        /// Comparison method.
        /// </summary>
        /// <param name="entity1">
        /// The entity 1.
        /// </param>
        /// <param name="entity2">
        /// The entity 2.
        /// </param>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            return entity1.Id.ToString() == entity2.Id.ToString();
        }

        /// <summary>
        /// Comparison operator.
        /// </summary>
        /// <param name="entity1">
        /// The entity 1.
        /// </param>
        /// <param name="entity2">
        /// The entity 2.
        /// </param>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return !(entity1 == entity2);
        }

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

        /// <summary>
        /// Equality comparison method.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public override bool Equals(object entity)
        {
            return entity != null
                   && entity is EntityBase<TId>
                   && this == (EntityBase<TId>)entity;
        }

        /// <summary>
        /// Method to get hash of this object.
        /// </summary>
        /// <returns>
        /// Hash code of this object.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

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