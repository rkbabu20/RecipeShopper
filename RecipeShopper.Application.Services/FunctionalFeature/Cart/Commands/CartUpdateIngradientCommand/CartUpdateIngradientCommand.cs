using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand
{
    /// <summary>
    /// CartUpdateIngradientCommand command
    /// </summary>
    public class CartUpdateIngradientCommand : IRequest<CartUpdateIngradientCommandResponse>
    {
        /// <summary>User Id</summary>
        public string? CartId { get; set; }
        /// <summary>Recipe</summary>
        public string? RecipeId { get; set; }
        /// <summary>Ingradient</summary>
        public CartIngradientDTO? Ingradient { get; set; }
    }
}
