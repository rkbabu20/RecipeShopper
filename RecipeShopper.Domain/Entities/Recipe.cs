using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Entities.Base;

namespace RecipeShopper.Domain.Entities
{
    public class Recipe : DataProperties
    {
        /// <summary>Recipe id</summary>
        public Guid RecipeId { get; set; }
        /// <summary>Recipe name</summary>
        public string? Name { get; set; }
        /// <summary>Ingradients</summary>
        public List<CartIngradient>? Ingradients { get; set;}
    }
}
