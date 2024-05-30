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
        /// <summary>Cart id</summary>
        public Guid Id { get; set; }
        /// <summary>User</summary>
        public User User { get; set; }
        /// <summary>Recipes</summary>
        public List<Recipe> Recipes { get; set; }
        /// <summary>Is order submission complete</summary>
        public bool IsOrderComplete { get; set; }
    }
}
