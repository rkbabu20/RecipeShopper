using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests.CartRequests;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Cart ingradients controller 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    [Authorize]
    public class CartIngradientsController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Cart Ingradients 
        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(typeof(CartAddIngradientCommandResponse), StatusCodes.Status200OK)]
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
        [HttpPut("update")]
        [ProducesResponseType(typeof(CartAddCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateIngradient([FromBody] CartUpdateIngradientRequest request)
        {
            // Add ingradients to cart
            var cartUpdateIngradientCommand = _mapper.Map<CartUpdateIngradientCommand>(request);
            var result = await _mediator.Send(cartUpdateIngradientCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(CartAddCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteIngradient([FromBody] CartDeleteIngradientRequest request)
        {
            // Add ingradients to cart
            var cartDeleteIngradientCommand = _mapper.Map<CartAddIngradientCommand>(request);
            var result = await _mediator.Send(cartDeleteIngradientCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }
        #endregion
    }// End CartIngradientsController
}
