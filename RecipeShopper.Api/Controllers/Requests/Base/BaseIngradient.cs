using RecipeShopper.Api.Controllers.Requests.Enums;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    /// <summary>
    /// Base ingradient 
    /// </summary>
    public class BaseIngradient
    {
        /// <summary>
        /// Ingradient Name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Quanity type
        /// </summary>
        public IngradientQuantityType QuantityType { get; set; }
    }// End BaseIngradient
}
