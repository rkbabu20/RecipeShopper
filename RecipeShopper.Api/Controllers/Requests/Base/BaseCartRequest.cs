using RecipeShopper.Api.Controllers.Requests.CartRequests;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    /// <summary>
    /// Base cart request
    /// </summary>
    public class BaseCartRequest
    {

        /// <summary>User Id</summary>
        public string? UserId { get; set; }
        /// <summary>Recipies</summary>
        public List<RecipeRequest>? Recipies { get; set; }
    }
}
