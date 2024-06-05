namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Cart delete ingradient request
    /// </summary>
    public class CartDeleteIngradientRequest
    {
        /// <summary>Cart Id</summary>
        public string CartId { get; set; }
        /// <summary>Recipe id</summary>
        public string RecipeId { get; set; }
        public string CartIngradientId { get; set; }
    }
}
