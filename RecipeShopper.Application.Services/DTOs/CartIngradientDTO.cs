using RecipeShopper.Application.Services.DTOs.Base;


namespace RecipeShopper.Application.Services.DTOs
{
    /// <summary>
    /// Cart Ingradient entity used in cart
    /// </summary>
    public class CartIngradientDTO : BaseIngradientDTO
    {
        /// <summary>Cart Ingradient id</summary>
        public Guid CartIngradientId { get; set; }
        /// <summary>Stock Ingradient id</summary>
        public Guid StockIngradientId {get; set;}
        /// <summary>Ordered quanity</summary>
        public int OrderedQuantity { get; set; }
    }
}
