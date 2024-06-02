namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    public class StockIngradientPatchRequest
    {
        public Guid StockIngradientId { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
