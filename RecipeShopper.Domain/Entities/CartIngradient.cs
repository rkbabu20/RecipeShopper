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
        public Guid StockIngradientId {get; set;}
        public int OrderedQuantity { get; set; }
    }
}
