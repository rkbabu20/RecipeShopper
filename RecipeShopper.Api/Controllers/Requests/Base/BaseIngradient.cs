using RecipeShopper.Api.Controllers.Requests.Enums;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    public class BaseIngradient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IngradientQuantityType QuantityType { get; set; }
    }
}
