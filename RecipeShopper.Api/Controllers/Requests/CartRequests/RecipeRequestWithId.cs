
namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Recipe request with id
    /// </summary>
    public class RecipeRequestWithId : RecipeRequest
    {
        /// <summary>
        /// RecipeId
        /// </summary>
        public Guid RecipeId { get; set; }
    }// End RecipeId
}
