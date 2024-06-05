using RecipeShopper.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Ingradient entity used for stocking
    /// </summary>
    public class StockIngradient : BaseIngradient
    {
        /// <summary>Stock ingradient id</summary>
        public Guid StockIngradientId { get; set; }
        /// <summary>Available quantity</summary>
        public int AvailableQuantity { get; set; }
    }
}
