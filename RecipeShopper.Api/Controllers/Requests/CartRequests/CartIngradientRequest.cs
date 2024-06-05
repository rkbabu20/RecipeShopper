using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Ingradient to add cart Recipe
    /// </summary>
    public class CartIngradientRequest 
    {
        public Guid StockIngradientId { get; set; }
        /// <summary>Ordered quanity</summary>
        public int OrderedQuantity { get; set; }
    }
}
