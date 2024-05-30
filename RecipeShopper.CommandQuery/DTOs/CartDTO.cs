using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.DTOs
{
    /// <summary>
    /// Cart
    /// </summary>
    public class CartDTO 
    {
        /// <summary>Cart id</summary>
        public Guid Id { get; set; }
        /// <summary>User</summary>
        public UserDTO User { get; set; }
        /// <summary>Recipes</summary>
        public List<RecipeDTO> Recipes { get; set; }
        /// <summary>Is order submission complete</summary>
        public bool IsOrderComplete { get; set; }
    }
}
