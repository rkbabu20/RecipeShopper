using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.AllStockIngradients
{
    /// <summary>
    /// Get All stock ingradient query
    /// </summary>
    /// <param name="stockIngradientId"></param>
    public class GetAllStockIngradientQuery : IRequest<GetAllStockIngradientResponse>
    {

    }
}
