using RecipeShopper.Api.Controllers.Requests.Enums;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    public class BaseIngradient
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int AvailableQuantity { get; set; }
        public IngradientQuantityType QuantityType { get; set; }
    }
}
