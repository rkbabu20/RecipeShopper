using RecipeShopper.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Ingradient entity used in cart
    /// </summary>
    public class CartIngradient : BaseIngradient
    {
        /// <summary>Ingradient id</summary>
        public Guid CartIngradientId { get; set; }
        /// <summary>Stock ingradient id</summary>
        public Guid StockIngradientId {get; set;}
        /// <summary>Ordered quantity</summary>
        public int OrderedQuantity { get; set; }
    }
}
