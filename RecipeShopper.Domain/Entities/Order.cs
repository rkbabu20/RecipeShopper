using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order : DataProperties
    {
        /// <summary>Order id</summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// String User Id
        /// </summary>
        public string UserId {  get; set; }
        /// <summary>
        /// Cart
        /// </summary>
        public Cart Cart { get; set; }
        /// <summary>
        /// Order Status
        /// </summary>
        public string OrderStatus { get; set; }

    }// Order
}
