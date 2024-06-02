using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.DeleteStockIngradientCommand
{
    /// <summary>
    /// Delete stock ingradient command 
    /// </summary>
    public class DeleteStockIngradientCommand(Guid stockIngradientId) : IRequest<DeleteStockIngradientCommandResponse>
    {
        /// <summary>Stock ingradientId</summary>
        public Guid StockIngradientId { get; set; } = stockIngradientId;
    }
}
