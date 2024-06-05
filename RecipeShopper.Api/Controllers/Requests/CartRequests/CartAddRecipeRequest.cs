using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Request to add Recipe to cart
    /// </summary>
    public class CartAddRecipeRequest : BaseRecipeRequest
    {
        /// <summary>Recipe to add</summary>
        public RecipeRequest? Recipe { get; set; }
    }
}
