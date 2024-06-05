using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class CartAddCommand(CartDTO cartDto):IRequest<CartAddCommandResponse>
    {
        /// <summary>
        /// Cart
        /// </summary>
        public CartDTO Cart { get; set; } = cartDto;
    }
}
