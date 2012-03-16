// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IProductRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Products
{
    using System.Collections.Generic;
    using Infrastructure.Domain;

    /// <summary>
    /// Interface for the products repository.
    /// </summary>
    public interface IProductRepository : IRepository<Product, int>
    {
        /// <summary>
        /// Get the list of order's products.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Collection of products.
        /// </returns>
        IEnumerable<Product> GetOrderProducts(int orderId);

        /// <summary>
        /// Add product to an order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        void AddProductToOrder(int orderId, Product product);

        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Remove product completely.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        void RemoveProduct(int productId);

        /// <summary>
        /// Request return of a product back to the shop.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        void RequestProductReturn(int productId);
    }
}