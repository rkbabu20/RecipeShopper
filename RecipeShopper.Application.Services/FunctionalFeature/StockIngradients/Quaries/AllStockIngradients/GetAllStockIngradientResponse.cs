
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.AllStockIngradients
{
    /// <summary>
    /// Get stock ingradient response
    /// </summary>
    public class GetAllStockIngradientResponse : BaseResponse
    {
        public GetAllStockIngradientResponse() { }
        public List<StockIngradientDTO>? StockIngradients { get; set; }
    }
}
