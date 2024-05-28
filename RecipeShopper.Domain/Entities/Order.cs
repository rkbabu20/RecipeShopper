using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    public class Order
    {
        public string OrderId { get; set; }
        public User User { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
