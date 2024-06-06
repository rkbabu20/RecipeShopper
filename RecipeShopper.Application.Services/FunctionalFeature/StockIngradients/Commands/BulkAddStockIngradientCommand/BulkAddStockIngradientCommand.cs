using MediatR;
using RecipeShopper.Application.Services.DTOs;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.BulkAddStockIngradientCommand
{
    /// <summary>
    /// Bulk Add stock ingradient command
    /// </summary>
    public class BulkAddStockIngradientCommand(List<StockIngradientDTO> stockIngradients) : IRequest<BulkAddStockIngradientCommandResponse>
    {
        /// <summary>
        /// Stockingradients collection
        /// </summary>
        public List<StockIngradientDTO>? StockIngradients { get; set; } = stockIngradients;
    }
}
