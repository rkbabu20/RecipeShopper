using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.PatchStockIngradientCommand
{
    /// <summary>
    /// Delete stock ingradient command 
    /// </summary>
    public class PatchStockIngradientCommand(Guid stockIngradientId, int availableQuantity) : IRequest<PatchStockIngradientCommandResponse>
    {
        /// <summary>Stock ingradientId</summary>
        public Guid StockIngradientId { get; set; } = stockIngradientId;
        /// <summary>Available quantity</summary>
        public int AvailableQuantity { get; set; } = availableQuantity;
    }
}
