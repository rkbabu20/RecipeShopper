using RecipeShopper.Domain.Aggregates.Base;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.RecipesAggregate
{
    /// <summary>
    /// Recipes aggregate
    /// </summary>
    public class RecipesAggregate : BaseAggregate
    {
        #region Constructor
        public RecipesAggregate(Recipe recipe) { Recipe = recipe; }
        public RecipesAggregate(List<Recipe> recipes) { Recipes = recipes; }
        #endregion

        #region Properties
        /// <summary>Recipe</summary>
        public Recipe? Recipe { get; set; }
        /// <summary>Recipes</summary>
        public List<Recipe>? Recipes { get; set; }
        #endregion
    }
}
