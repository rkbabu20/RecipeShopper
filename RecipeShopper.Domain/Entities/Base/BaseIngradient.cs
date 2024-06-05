using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeShopper.Domain.Enums;

namespace RecipeShopper.Domain.Entities.Base
{
    /// <summary>
    /// Ingradient
    /// </summary>
    public class BaseIngradient : DataProperties
    {
        /// <summary>In gradient name</summary>
        public string? Name { get; set; }
        /// <summary>Price per quantity</summary>
        public decimal PricePerQuantity { get; set; }

        /// <summary>Ingradient description</summary>
        public string? Description { get; set; }

        /// <summary>Ingradient quantity type</summary>
        public IngradientQuantityType QuantityType { get; set; }

    }// End Ingradient
}
