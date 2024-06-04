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
        public static void PrepareCartForAdd(this Cart cart)
        {
            if (cart != null && cart.Recipes != null && cart.Recipes.Any())
            {
                cart.ApplyDateProperties(true, false);
                cart.CartId = Guid.NewGuid();
                cart.TotalPrice = cart.Recipes!.Sum(x => x.Ingradients!.Sum(i => i.OrderedQuantity * i.PricePerQuantity));
                foreach (var recipe in cart.Recipes)
                {
                    recipe.CartId = Guid.NewGuid();
                    recipe.RecipeId = Guid.NewGuid();
                    recipe.Ingradients?.ForEach(i => i.CartIngradientId = Guid.NewGuid());
                }
            }
        }
    }
}
