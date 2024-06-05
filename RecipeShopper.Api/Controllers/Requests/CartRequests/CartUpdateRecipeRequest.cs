namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Request to add Recipe to cart
    /// </summary>
    public class CartUpdateRecipeRequest
    {

        /// <summary>Cart Id</summary>
        public string? CartId { get; set; }
        /// <summary>Recipe to add</summary>
        public RecipeRequestWithId? Recipe { get; set; }
    }
}
