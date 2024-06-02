using RecipeShopper.CommandQuery.DTOs.Base;
using RecipeShopper.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Cart Ingradient entity used in cart
    /// </summary>
    public class CartIngradientDTO : BaseIngradientDTO
    {
        /// <summary>Cart Ingradient id</summary>
        public Guid CartIngradientId { get; set; }
        /// <summary>Stock Ingradient id</summary>
        public Guid StockIngradientId {get; set;}
        /// <summary>Ordered quanity</summary>
        public int OrderedQuantity { get; set; }
    }
}
