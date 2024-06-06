using Microsoft.EntityFrameworkCore;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Data.Repositories.Extensions
{
    /// <summary>
    /// Cart ingradient extensions
    /// </summary>
    public static class CartIngradientExtensions
    {
        /// <summary>
        /// Remove cart ingradient extensions
        /// </summary>
        /// <param name="cartIngradient">CartIngradient</param>
        /// <param name="dbContext">RecipeShopperDbContext</param>
        public static void Remove(this CartIngradient cartIngradient, RecipeShopperDbContext dbContext)
        {
            if (cartIngradient != null && dbContext != null)
            {
                var ingradient = dbContext.CartIngradients.FirstOrDefault(x => x.CartIngradientId == cartIngradient.CartIngradientId);
                dbContext.CartIngradients.Remove(cartIngradient);
            }
        }// End Remove

        
        /// <summary>
        /// Add cart ingradient 
        /// </summary>
        /// <param name="cartIngradient"></param>
        /// <param name="dbContext"></param>
        public static void Add(this CartIngradient cartIngradient, RecipeShopperDbContext dbContext)
        {
            if (cartIngradient != null && dbContext != null)
            {
                dbContext.CartIngradients.Add(cartIngradient);
            }
        }
    }
}
