using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class SubmitOrderCommand : IRequest<SubmitOrderCommandResponse>
    {
        /// <summary>User Id</summary>
        public string UserId { get; set; }
        /// <summary>Cart Id</summary>
        public string CartId { get; set; }
    }
}
