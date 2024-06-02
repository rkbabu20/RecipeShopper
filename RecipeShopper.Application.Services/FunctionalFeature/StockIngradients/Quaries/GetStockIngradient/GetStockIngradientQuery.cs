using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.GetStockIngradient
{
    /// <summary>
    /// Get stock ingradient query
    /// </summary>
    /// <param name="stockIngradientId"></param>
    public class GetStockIngradientQuery(Guid stockIngradientId) : IRequest<GetStockIngradientResponse>
    {
        /// <summary>Stock ingradient id</summary>
        public Guid StockIngradientId { get; set; } = stockIngradientId;
    }
}
