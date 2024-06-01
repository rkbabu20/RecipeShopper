using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order : DataProperties
    {
        /// <summary>Order id</summary>
        public Guid OrderId { get; set; }
        /// <summary>User</summary>
        public User? User { get; set; }
        /// <summary>Recipes</summary>
        public List<Recipe>? Recipes { get; set; }
    }// Order
}
