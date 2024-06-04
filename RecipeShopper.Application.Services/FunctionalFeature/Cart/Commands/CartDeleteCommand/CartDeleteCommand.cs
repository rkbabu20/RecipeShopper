﻿using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteCommand
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class CartDeleteCommand : IRequest<CartDeleteCommandResponse>
    {
        /// <summary>User Id</summary>
        public string UserId { get; set; }
        /// <summary>User Id</summary>
        public string CartId { get; set; }
    }
}
