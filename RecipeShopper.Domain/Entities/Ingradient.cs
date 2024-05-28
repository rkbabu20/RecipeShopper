using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Enums;

namespace RecipeShopper.Domain.Entities
{
    public class Ingradient : DataProperties
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public IngradientQuantityType QuantityType { get; set; }

     }
}
    