namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    public class CartAddRecipeRequest
    {
        public string? UserId { get; set; }
        public string? CartId { get; set; }
        public RecipeRequest? Recipe { get; set; }
    }
}
