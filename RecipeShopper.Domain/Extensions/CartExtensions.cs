using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Entities;
namespace RecipeShopper.Domain.Extensions
{
    /// <summary>
    /// Cart extensions
    /// </summary>
    public static class CartExtensions
    {
        /// <summary>
        /// Get cart total price
        /// </summary>
        /// <param name="cart">Cart</param>
        /// <returns></returns>
        public static decimal GetTotalPrice(this Cart cart)
        {
            return cart != null ? cart.Recipes.Sum(x => x.Ingradients.Sum(i => i.OrderedQuantity * i.PricePerQuantity)) : 0;
        }// End GetTotalPrice
    }
}
