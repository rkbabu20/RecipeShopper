using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    /// <summary>
    /// Bulk Stock ingradient add request
    /// </summary>
    public class BulkStockIngradientAddRequest 
    {
        /// <summary>
        /// Stock ingradient requests collection
        /// </summary>
       public List<StockIngradientAddRequest> StockIngradients { get; set; }
    }
}
