using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.DTOs;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.StockIngradients.GetStockIngradient
{
    /// <summary>
    /// Get stock ingradient response
    /// </summary>
    public class GetStockIngradientResponse : BaseResponse
    {
        public GetStockIngradientResponse() { }
        public StockIngradientDTO? StockIngradient { get; set; }

    }
}
