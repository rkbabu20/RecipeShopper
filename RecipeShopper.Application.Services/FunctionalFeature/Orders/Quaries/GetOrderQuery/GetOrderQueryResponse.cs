using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery
{
    /// <summary>
    /// Get order query response
    /// </summary>
    public class GetOrderQueryResponse : BaseResponse
    {
        /// <summary>
        /// Order
        /// </summary>
        public OrderDTO? Order { get; set; }
    }
}
