using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteCommand
{

    /// <summary>
    /// Cart delete command
    /// </summary>
    /// <param name="cartId"></param>
    public class CartDeleteCommand(string cartId) : IRequest<CartDeleteCommandResponse>
    {
        /// <summary>Cart Id</summary>
        public string CartId { get; set; } = cartId;
    }
}
