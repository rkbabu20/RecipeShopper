using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Application.Services.Extensions
{
    /// <summary>
    /// Cart extension
    /// </summary>
    public static class CartExtensions
    {
        /// <summary>
        /// Prepare cart for add
        /// </summary>
        /// <param name="cart"></param>
        public static void PrepareCartForAdd(this Cart cart, List<StockIngradient> stockIngradients)
        {
            if (cart != null && cart.Recipes != null && cart.Recipes.Any())
            {
                cart.ApplyDateProperties(true, false);
                cart.CartId = Guid.NewGuid();
                cart.TotalPrice = cart.Recipes!.Sum(x => x.Ingradients!.Sum(i => i.OrderedQuantity * i.PricePerQuantity));
                cart.Recipes.ForEach(recipe => recipe.PrepareRecipeForAdd(stockIngradients));
            }
        }

        /// <summary>
        /// Prepare cart for update
        /// </summary>
        /// <param name="cart"></param>
        public static void PrepareCartForUpdate(this Cart cart, List<StockIngradient> stockIngradients)
        {
            cart.PrepareCartForAdd(stockIngradients);
        }
    }
}
