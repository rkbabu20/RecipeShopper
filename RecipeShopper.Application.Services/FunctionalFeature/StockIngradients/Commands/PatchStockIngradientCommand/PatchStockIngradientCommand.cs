using MediatR;


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
