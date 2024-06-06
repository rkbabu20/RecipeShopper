using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests.CartRequests;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateRecipeCommand;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Recipe controller to Add/Update/Delete Recipe to Cart
    /// </summary>
    /// <param name="mediator">IMediator</param>
    /// <param name="mapper">IMapper</param>
    //[Authorize]
    public class RecipeController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region Cart Recipe Actions
        /// <summary>
        /// Add Recipe to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(typeof(CartAddCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddRecipe([FromBody] CartAddRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartAddRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Update recipe cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(CartUpdateRecipeCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateRecipe([FromBody] CartUpdateRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartUpdateRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Delete recipe from cart 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(CartDeleteRecipeCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteRecipe([FromBody] CartDeleteRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartDeleteRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }
        #endregion
    }
}
