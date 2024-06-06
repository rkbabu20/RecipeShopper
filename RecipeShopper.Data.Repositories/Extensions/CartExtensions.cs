using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Data.Repositories.Extensions
{
    /// <summary>
    /// Cart extensions
    /// </summary>
    public static class CartExtensions
    {
        /// <summary>
        /// Region remove cart from dbcontext
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="dbContext"></param>
        public static void Remove(this Cart cart, RecipeShopperDbContext dbContext)
        {
            if(cart !=null &&  dbContext != null)
            {
                if (cart.Recipes != null && cart.Recipes.Any())
                    cart.Recipes.ForEach(recipe => recipe.Remove(dbContext));
                dbContext.Cart.Remove(cart);
            }
        }


        /// <summary>
        /// Region remove cart from dbcontext
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="dbContext"></param>
        public static void Add(this Cart cart, RecipeShopperDbContext dbContext)
        {
            if (cart != null && dbContext != null)
            {
                if (cart.Recipes != null && cart.Recipes.Any())
                    cart.Recipes.ForEach(recipe => recipe.Add(dbContext));
                dbContext.Cart.Add(cart);
            }
        }
    }
}
