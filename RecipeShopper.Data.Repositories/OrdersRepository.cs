using Azure.Core;
using RecipeShopper.Application.Contracts;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    public class OrdersRepository(RecipeShopperDbContext dbContext) : IOrdersRepository
    {
        /// <summary>
        /// Delete Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task DeleteAsync(GenericRequest request)
        {
            if(request !=null)
            {
                // Step 1: Get the order 
                var order = dbContext.Orders.FirstOrDefault(p => p.OrderId == request.RequestId);
                if (order != null)
                {
                    // Step 2 : Reset the availability quantity for all stock ingradients
                    var cartIngradients = order.Cart.Recipes!.SelectMany(r => r.Ingradients!.ToList()).GroupBy(e => e.StockIngradientId);
                    var stockIngradients = dbContext.StockIngradients.ToList();
                    if (stockIngradients.Any())
                    {
                        foreach (var item in cartIngradients)
                        {
                            var sIngradient = stockIngradients.Find(p => p.StockIngradientId == item.Key);
                            sIngradient!.AvailableQuantity = sIngradient.AvailableQuantity + item.Sum(p => p.OrderedQuantity);
                        }
                    }
                    // Step 3 : Remote Order
                    dbContext.Orders.Remove(order);
                    // Step 4 : Save DB changes
                    dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OrdersAggregate> GetAllAsync(GenericRequest request)
        {
            return new OrdersAggregate(dbContext.Orders.Where(x => x.UserId.Equals(request.Id)).ToList());
        }

        /// <summary>
        /// Get Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<OrdersAggregate> GetAsync(GenericRequest request)
        {
            return new OrdersAggregate(dbContext.Orders.First(p => p.OrderId == request.RequestId)); 
        }

        /// <summary>
        /// Submit order
        /// </summary>
        /// <param name="ordersAggregate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task SubmitAsync(OrdersAggregate ordersAggregate)
        {
            if (ordersAggregate != null && ordersAggregate.Order != null)
            {
                // Step 2 : Reset the availability quantity for all stock ingradients
                var cartIngradients = ordersAggregate.Order.Cart.Recipes!.SelectMany(r => r.Ingradients!.ToList()).GroupBy(e => e.StockIngradientId);
                var stockIngradients = dbContext.StockIngradients.ToList();
                if (stockIngradients.Any())
                {
                    foreach (var item in cartIngradients)
                    {
                        var sIngradient = stockIngradients.Find(p => p.StockIngradientId == item.Key);
                        var orderedQuantity = item.Sum(p => p.OrderedQuantity);
                        if (sIngradient.AvailableQuantity >= orderedQuantity)
                            sIngradient.AvailableQuantity = sIngradient.AvailableQuantity - item.Sum(p => p.OrderedQuantity);
                        else ordersAggregate.ValidationErrors.Add($"{sIngradient.Name} not having sufficient quantity to order. Ordered quantity{orderedQuantity} but available quantity {sIngradient.AvailableQuantity}");
                    }
                    if (!ordersAggregate.ValidationErrors!.Any())
                    {
                        UpdateCartForOrderSubmit(ordersAggregate.Order);
                        // Save changes to db
                        dbContext.SaveChanges();
                    }
                    else ordersAggregate.IsAdded = false;
                }
            }
        }

        private void UpdateCartForOrderSubmit(Order order)
        {
            if (order != null)
            {
                var cart = dbContext.Cart.FirstOrDefault(C => C.CartId == order.Cart.CartId);
                cart.OrderId= order.OrderId;
                cart.ModifiedDate = order.Cart.ModifiedDate;
                dbContext.Orders.Add(order);
            }
        }

    }
}
