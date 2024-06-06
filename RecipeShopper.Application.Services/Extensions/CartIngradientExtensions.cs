using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Extensions
{
    /// <summary>
    /// CartIngradient Extensions
    /// </summary>
    public static class CartIngradientExtensions
    {
        /// <summary>
        /// Prepare recipe for add
        /// </summary>
        /// <param name="recipe"></param>
        public static void PrepareCartIngradientForAdd(this CartIngradient cartIngradient, StockIngradient stockIngradient)
        {
            if (cartIngradient != null && stockIngradient != null)
            {
                cartIngradient.CartIngradientId = Guid.NewGuid();
                cartIngradient.ApplyDateProperties(true, false);
                cartIngradient.PricePerQuantity = stockIngradient.PricePerQuantity;
                cartIngradient.QuantityType = stockIngradient.QuantityType;
                cartIngradient.Description = stockIngradient.Description;
                cartIngradient.Name = stockIngradient.Name;
            }
        }
    }
}
