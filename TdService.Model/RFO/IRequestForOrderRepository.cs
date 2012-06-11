// -----------------------------------------------------------------------
// <copyright file="IRequestForOrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.RFO
{
    /// <summary>
    /// Interface for request for order repository.
    /// </summary>
    public interface IRequestForOrderRepository
    {
        /// <summary>
        /// Add new request for order.
        /// </summary>
        /// <param name="requestForOrder">
        /// The request for order.
        /// </param>
        void AddRequestForOrder(RequestForOrder requestForOrder);

        /// <summary>
        /// Remove request for order by ID.
        /// </summary>
        /// <param name="requestId">
        /// The request for order unique id.
        /// </param>
        void RemoveRequestForOrder(int requestId);
    }
}