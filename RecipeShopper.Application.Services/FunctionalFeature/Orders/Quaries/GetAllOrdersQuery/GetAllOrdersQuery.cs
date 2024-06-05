using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetAllOrdersQuery
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class GetAllOrdersQuery(string userId) : IRequest<GetAllOrdersQueryResponse>
    {
        /// <summary>User Id</summary>
        public string UserId { get; set; } = userId;
    }
}
