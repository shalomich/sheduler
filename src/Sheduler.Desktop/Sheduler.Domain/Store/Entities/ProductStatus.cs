namespace Sheduler.Domain.Store.Entities
{
    /// <summary>
    /// Product status.
    /// </summary>
    public enum ProductStatus : short
    {
        /// <summary>
        /// The product is in store.
        /// </summary>
        InStore,

        /// <summary>
        /// The product is available for pre-order.
        /// </summary>
        PreOrder,

        /// <summary>
        /// The product is not available.
        /// </summary>
        Unavailable
    }
}
