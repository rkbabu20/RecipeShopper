using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class CartAddRecipeCommand :IRequest<CartAddRecipeCommandResponse>
    {

        /// <summary>Cart Id</summary>
        public string CartId { get; set; }
        /// <summary>Recipe</summary>
        public RecipeDTO Recipe { get; set; }
    }
}
