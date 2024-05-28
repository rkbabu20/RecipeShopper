using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BaseIngradient> Ingredients { get; set; }
    }
}
