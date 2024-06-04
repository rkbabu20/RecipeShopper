using RecipeShopper.Domain.Aggregates.Base;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.CartAggregate
{
    /// <summary>
    /// Cart aggregate
    /// </summary>
    public class CartAggregate : BaseAggregate
    {
        #region Constructor
        public CartAggregate(Cart cart) { Cart = cart; }
        public CartAggregate(CartIngradient cartIngradient) { CartIngradient = cartIngradient; }
        public CartAggregate(Recipe recipe) { Recipe = recipe; }
        #endregion

        public Cart Cart { get; set; }
        public CartIngradient CartIngradient { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsCartExists { get; set; }
    }
}
