using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteIngradientCommand
{
    /// <summary>
    /// Cart delete command
    /// </summary>
    public class CartDeleteIngradientCommand : IRequest<CartDeleteIngradientCommandResponse>
    {
        /// <summary>Cart Id</summary>
        public string CartId { get; set; }
        /// <summary>Recipe id</summary>
        public string RecipeId { get; set; }
        public string CartIngradientId { get; set; }

    }
}
