using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Enums;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Ingradient
    /// </summary>
    public class Ingradient : DataProperties
    {
        /// <summary>Ingradient id</summary>
        public int Id { get; set; }
        /// <summary>In gradient name</summary>
        public string? Name { get; set; }
        /// <summary>Ingradient description</summary>
        public string? Description { get; set; }
        /// <summary>Ingradient quantity</summary>
        public int Quantity { get; set; }
        /// <summary>Ingradient quantity type</summary>
        public IngradientQuantityType QuantityType { get; set; }

    }// End Ingradient
}
    