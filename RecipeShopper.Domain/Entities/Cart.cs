using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Cart
    /// </summary>
    public class Cart : DataProperties
    {
        public Cart() { Recipes = new List<Recipe>(); }
        /// <summary>Cart id</summary>
        public Guid CartId { get; set; }
        /// <summary>User Id </summary>
         
        public Guid? OrderId { get; set; }
        public string? UserId { get; set; }
        /// <summary>Recipes</summary>
        public List<Recipe>? Recipes { get; set; }
        /// <summary>Total price</summary>
        public decimal TotalPrice { get; set; }
    }
}
