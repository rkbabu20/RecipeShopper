using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.CommandQuery.DTOs.Base;
using RecipeShopper.Domain.Entities.Base;
using RecipeShopper.Domain.Enums;

namespace RecipeShopper.CommandQuery.DTOs
{
    /// <summary>
    /// StockIngradientDTO
    /// </summary>
    public class StockIngradientDTO  : BaseIngradientDTO
    {
        /// <summary>StockIngradientId</summary>
        public Guid StockIngradientId { get; set; }
        /// <summary>StockIngradient available quantity</summary>
        public int AvailableQuantity { get; set; }

    }// End StockIngradientDTO
}
    