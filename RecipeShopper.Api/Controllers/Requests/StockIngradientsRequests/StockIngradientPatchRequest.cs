namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    /// <summary>
    /// Stock ingradient path request
    /// Request to update quantity
    /// </summary>
    public class StockIngradientPatchRequest
    {
        /// <summary>Stock ingradient id</summary>
        public Guid StockIngradientId { get; set; }
        /// <summary>Available quantity</summary>
        public int AvailableQuantity { get; set; }
    }
}
