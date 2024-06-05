using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Cart delete recipe request
    /// </summary>
    public class CartDeleteRecipeRequest : BaseRecipeRequest
    {
        /// <summary>Recipe Id</summary>
        public string RecipeId { get; set; }
    }
}
