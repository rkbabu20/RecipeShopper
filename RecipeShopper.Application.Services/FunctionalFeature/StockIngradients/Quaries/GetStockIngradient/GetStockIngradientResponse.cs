using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.GetStockIngradient
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
