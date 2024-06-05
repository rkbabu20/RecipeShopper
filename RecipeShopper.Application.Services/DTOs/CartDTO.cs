using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.DTOs
{
    /// <summary>
    /// Cart
    /// </summary>
    public class CartDTO 
    {
        /// <summary>Cart id</summary>
        public Guid CartId { get; set; }
        /// <summary>User Id </summary>
        public string UserId { get; set; }
        /// <summary>User</summary>
        public List<RecipeDTO> Recipes { get; set; }
        /// <summary>Total price</summary>
        public decimal TotalPrice { get; set; }
        /// <summary>Is order submission complete</summary>
        public bool IsOrderComplete { get; set; }
    }
}
