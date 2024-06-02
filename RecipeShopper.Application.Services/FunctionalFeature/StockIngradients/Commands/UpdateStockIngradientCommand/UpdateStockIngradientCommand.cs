using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.UpdateStockIngradientCommand
{
    /// <summary>
    /// Delete stock ingradient command 
    /// </summary>
    public class UpdateStockIngradientCommand(StockIngradientDTO stockIngradientDTO) : IRequest<UpdateStockIngradientCommandResponse>
    {
        /// <summary>Stock ingradientId</summary>
        public StockIngradientDTO StockIngradient { get; set; } = stockIngradientDTO;
    }
}
