using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery
{
    /// <summary>
    /// Get order query
    /// </summary>
    /// <param name="orderId">orderId</param>
    public class GetOrderQuery(string orderId) : IRequest<GetOrderQueryResponse>
    {
        /// <summary>Order Id</summary>
        public string OrderId { get; set; }
    }
}
