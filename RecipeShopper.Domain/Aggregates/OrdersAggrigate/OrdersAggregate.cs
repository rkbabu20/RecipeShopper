using RecipeShopper.Domain.Aggregates.Base;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Aggregates.OrdersAggrigate
{
    /// <summary>
    /// Orders aggregate
    /// </summary>
    public class OrdersAggregate : BaseAggregate
    {
        /// <summary>
        /// Order aggregate
        /// </summary>
        /// <param name="order">Order</param>
        public OrdersAggregate(Order order) { Order = order; }
        /// <summary>
        /// Orders aggregate
        /// </summary>
        /// <param name="orders">Orders</param>
        public OrdersAggregate(List<Order> orders) { Orders = Orders; }
        /// <summary>Order</summary>
        public Order? Order { get; set; }
        /// <summary>Orders</summary>
        public List<Order>? Orders { get; set; }
    }
}
