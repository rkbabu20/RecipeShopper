using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    /// <summary>Stock ingradient update request</summary>
    public class StockIngradientUpdateRequest : BaseIngradient
    {
        /// <summary>Stock ingradient id</summary>
        public Guid StockIngradientId { get; set; }
        /// <summary>Available quantity</summary>
        public int AvailableQuantity { get; set; }
    }
}
