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
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Cart controller to handle cart actions
    /// Add/Update/Delete/Get Cart
    /// Add/Update/Delete Ingradient with Recipe with Cart
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
   //[Authorize]
    public class CartController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Cart Actions
        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(typeof(CartAddCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddCart([FromBody] CartAddRequest request)
        {
            // Add cart
            var cart = _mapper.Map<CartDTO>(request);
            var result = await _mediator.Send(new CartAddCommand(cart)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Get specific user cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(GetCartQueryResponse), StatusCodes.Status200OK)]
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
        [HttpDelete("{cartId}")]
        [ProducesResponseType(typeof(CartDeleteCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] string cartId)
        {
            var result = await _mediator.Send(new CartDeleteCommand(cartId)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Update whole cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(CartUpdateCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CartUpdateRequest request)
        {
            // update cart
            var cart = _mapper.Map<CartDTO>(request);
            var result = await _mediator.Send(new CartUpdateCommand(cart)).ConfigureAwait(false);
            return GetObjectResult(result);
        }
        #endregion

    }
}
