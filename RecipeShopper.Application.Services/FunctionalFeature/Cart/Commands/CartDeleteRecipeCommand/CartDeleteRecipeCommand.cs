using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteRecipeCommand
{
    /// <summary>
    /// Cart add command
    /// </summary>
    /// <param name="cartDto">CartDTO</param>
    public class CartDeleteRecipeCommand : IRequest<CartDeleteRecipeCommandResponse>
    {
        /// <summary>User Id</summary>
        public string UserId { get; set; }
        /// <summary>User Id</summary>
        public string CartId { get; set; }
        /// <summary>Recipe Id</summary>
        public string RecipeId { get; set; }
    }
}
