using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests
{
    public class StockIngradientUpdateRequest : BaseIngradient
    {
        public Guid StockIngradientId { get; set; }
    }
}
