using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests.CartRequests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;

namespace RecipeShopper.Api.Controllers
{
    [Authorize]
    public class CartController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion

        /// <summary>
        /// Get specific user cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            // Get cart
            var result = await _mediator.Send(new GetCartQuery(userId)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Delete whole cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            // Delete the cart from DB
            var result = new { IsSuucess = "true", Message = "User cart deleted" };
            return Ok(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddCart([FromBody] CartAddRequest request)
        {
            // Add cart
            var cart = _mapper.Map<CartDTO>(request);
            cart.User = new UserDTO() { Id=request.UserId };
            var result = await _mediator.Send(new CartAddCommand(cart)).ConfigureAwait(false);
            return GetObjectResult(result);
        }
        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("recipe/add")]
        public async Task<IActionResult> AddRecipe([FromBody] CartAddRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartAddRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("recipe/update")]
        public async Task<IActionResult> UpdateRecipe([FromBody] CartAddRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartAddRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("recipe/delete")]
        public async Task<IActionResult> DeleteRecipe([FromBody] CartAddRecipeRequest request)
        {
            // Add Recipe to cart
            var cartAddRecipeCommand = _mapper.Map<CartAddRecipeCommand>(request);
            var result = await _mediator.Send(cartAddRecipeCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("recipe/ingradient/add")]
        public async Task<IActionResult> AddIngradient([FromBody] CartAddIngradientRequest request)
        {
            // Add ingradients to cart
            var cartAddIngradientCommand = _mapper.Map<CartAddIngradientCommand>(request);
            var result = await _mediator.Send(cartAddIngradientCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("recipe/ingradient/update")]
        public async Task<IActionResult> UpdateIngradient([FromBody] CartAddIngradientRequest request)
        {
            // Add ingradients to cart
            var cartAddIngradientCommand = _mapper.Map<CartAddIngradientCommand>(request);
            var result = await _mediator.Send(cartAddIngradientCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("recipe/ingradient/delete")]
        public async Task<IActionResult> DeleteIngradient([FromBody] CartAddIngradientRequest request)
        {
            // Add ingradients to cart
            var cartAddIngradientCommand = _mapper.Map<CartAddIngradientCommand>(request);
            var result = await _mediator.Send(cartAddIngradientCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }
    }
}
