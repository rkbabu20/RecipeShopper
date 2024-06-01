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
        public CartAggregate(Cart cart) { Cart = cart; }
        public Cart Cart { get; set; }
    }
}
