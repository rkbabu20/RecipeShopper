using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    public class CartIngradientRequest : BaseIngradient
    {
        /// <summary>Cart Ingradient id</summary>
        public Guid CartIngradientId { get; set; }
        /// <summary>Stock Ingradient id</summary>
        public Guid StockIngradientId { get; set; }
        /// <summary>Ordered quanity</summary>
        public int OrderedQuantity { get; set; }
    }
}
