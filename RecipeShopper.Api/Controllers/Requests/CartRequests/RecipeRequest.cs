using RecipeShopper.Api.Controllers.Requests.Base;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Recipe request
    /// </summary>
    public class RecipeRequest
    {
        /// <summary>Recipe Name</summary>
        public string? Name { get; set; }
        /// <summary>Cart ingradients</summary>
        public List<CartIngradientRequest>? Ingredients { get; set; }
    }
}
