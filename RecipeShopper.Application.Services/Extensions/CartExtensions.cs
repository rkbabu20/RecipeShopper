using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void PrepareCartForAdd(this Cart cart,List<StockIngradient> stockIngradients)
        {
            if (cart != null && cart.Recipes != null && cart.Recipes.Any())
            {
                cart.ApplyDateProperties(true, false);
                cart.CartId = Guid.NewGuid();
                cart.TotalPrice = cart.Recipes!.Sum(x => x.Ingradients!.Sum(i => i.OrderedQuantity * i.PricePerQuantity));
                cart.Recipes.ForEach(recipe =>
                {
                    
                    recipe.ApplyDateProperties(true, false);
                    recipe.RecipeId = Guid.NewGuid();
                    recipe.Ingradients?.ForEach(ing =>
                    {
                        var stockIngradient = stockIngradients.FirstOrDefault(x => x.StockIngradientId == ing.StockIngradientId);
                       
                        ing.CartIngradientId = Guid.NewGuid();
                        ing.ApplyDateProperties(true, false);
                        ing.PricePerQuantity = stockIngradient.PricePerQuantity;
                        ing.QuantityType = stockIngradient.QuantityType;
                        ing.Description = ing.Description;
                        ing.Name = ing.Name;
                    });
                });
            }
        }
        /// <summary>
        /// Prepare cart for add
        /// </summary>
        /// <param name="cart"></param>
        public static void PrepareCartForUpdate(this Cart cart, List<StockIngradient> stockIngradients)
        {
            cart.PrepareCartForAdd(stockIngradients);
        }
    }
}
