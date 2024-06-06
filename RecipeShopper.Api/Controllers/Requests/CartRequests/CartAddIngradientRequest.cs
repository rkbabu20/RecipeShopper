namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Cart add ingradient request
    /// </summary>
    public class CartAddIngradientRequest
    {
        /// <summary>Cart id</summary>
        public string? CartId { get; set;}
        /// <summary>Recipe id</summary>
        public string? RecipeId { get; set;}
        /// <summary>Cart Ingradient</summary>
        public CartIngradientRequest? Ingradient { get; set; }
    }
}
