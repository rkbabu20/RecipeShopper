using RecipeShopper.Api.Controllers.Requests.CartRequests;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    public class BaseCartRequest
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public List<RecipeRequest>? Recipies { get; set; }
    }
}
