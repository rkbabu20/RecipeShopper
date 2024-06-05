using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.DTOs
{
    /// <summary>
    /// Recipe DTO
    /// </summary>
    public class RecipeDTO
    {
        /// <summary>Recipe id</summary>
        public Guid RecipeId { get; set; }
        /// <summary>Recipe name</summary>
        public string? Name { get; set; }
        /// <summary>Ingradients</summary>
        public List<CartIngradientDTO>? Ingradients { get; set;}
    }
}
