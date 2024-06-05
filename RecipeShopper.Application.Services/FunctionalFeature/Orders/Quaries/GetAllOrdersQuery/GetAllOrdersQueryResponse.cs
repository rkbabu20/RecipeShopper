using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetAllOrdersQuery
{
    /// <summary>
    /// Get all orders
    /// </summary>
    public class GetAllOrdersQueryResponse : BaseResponse
    {
        /// <summary>
        /// Orders
        /// </summary>
        public List<OrderDTO>? Orders { get; set; }
    }
}
