using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    /// <summary>
    /// Stock ingradient add request
    /// </summary>
    public class StockIngradientAddRequest : BaseIngradient
    {
        /// <summary>Available quantity</summary>
        public int AvailableQuantity { get; set; }
    }
}
