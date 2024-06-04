using RecipeShopper.Api.Controllers.Requests.Base;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    public class RecipeRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<CartIngradientRequest>? Ingredients { get; set; }
    }
}
