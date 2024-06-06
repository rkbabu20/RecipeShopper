using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Extensions
{
    /// <summary>
    /// Recipe extensions
    /// </summary>
    public static class RecipeExtensions
    {
        /// <summary>
        /// Prepare recipe for add
        /// </summary>
        /// <param name="recipe"></param>
        public static void PrepareRecipeForAdd(this Recipe recipe, List<StockIngradient> stockIngradients)
        {
            if (recipe != null)
            {
                recipe.RecipeId = Guid.NewGuid();
                recipe.ApplyDateProperties(true, false);
                if (recipe.Ingradients != null && recipe.Ingradients.Any())
                    recipe.Ingradients.ForEach(ing =>
                    {
                        var stockIngradient = stockIngradients.FirstOrDefault(x => x.StockIngradientId == ing.StockIngradientId);
                        ing.PrepareCartIngradientForAdd(stockIngradient);
                    });
            }
        }
    }
}
