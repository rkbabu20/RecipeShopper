using RecipeShopper.Domain.Aggregates.Base;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.IngradientsAggregate
{
    /// <summary>
    /// Cart ingradients aggregate
    /// </summary>
    public class CartIngradientsAggregate : BaseAggregate
    {
        #region constructor
        /// <summary>
        /// Cart ingradients aggregate
        /// </summary>
        /// <param name="cartIngradients">Cart ingradients</param>
        public CartIngradientsAggregate(List<CartIngradient> cartIngradients)
        {
            CartIngradients = cartIngradients;
        }
        /// <summary>
        /// Cart ingradients aggregate
        /// </summary>
        /// <param name="cartIngradient"></param>
        public CartIngradientsAggregate(CartIngradient cartIngradient)
        {
            CartIngradient = cartIngradient; ;
        }
        #endregion

        #region Properties
        /// <summary>Cart Ingradient</summary>
        public CartIngradient? CartIngradient { get; set; }
        /// <summary>Cart Ingradients</summary>
        public List<CartIngradient>? CartIngradients { get; set; }
        #endregion
    }
}
