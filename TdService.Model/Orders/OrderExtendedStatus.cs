namespace TdService.Model.Orders
{
    public enum OrderExtendedStatus
    {
        /// <summary>
        /// This order was created by operator.
        /// </summary>
        CreatedByOperator = 0,

        /// <summary>
        /// Return of an order has been requested by an user.
        /// </summary>
        ReturnRequested = 1,

        /// <summary>
        /// Return is processed by operator.
        /// </summary>
        ReturnInProgress = 2
    }
}