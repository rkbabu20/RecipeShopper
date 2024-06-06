using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Entities;


namespace RecipeShopper.Data.Repositories.Extensions
{
    /// <summary>
    /// Recoe extemsopms
    /// </summary>
    public static class RecipeExtensions
    {
        /// <summary>
        /// Recipe - Remove
        /// </summary>
        /// <param name="recipe">Recipe</param>
        /// <param name="dbContext">RecipeShopperDbContext</param>
        public static void Remove(this Recipe recipe, RecipeShopperDbContext dbContext)
        {
            if (recipe != null && dbContext != null)
            {
                if (recipe.Ingradients != null && recipe.Ingradients.Any())
                    recipe.Ingradients.ForEach(ingradient => ingradient.Remove(dbContext));
                dbContext.Recipes.Remove(recipe);
            }
        }

        /// <summary>
        /// Add Recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="dbContext"></param>
        public static void Add(this Recipe recipe, RecipeShopperDbContext dbContext)
        {
            if (recipe != null && dbContext != null)
            {
                if (recipe.Ingradients != null && recipe.Ingradients.Any())
                    recipe.Ingradients.ForEach(ingradient => ingradient.Add(dbContext));
                dbContext.Recipes.Add(recipe);
            }
        }
    }
}
