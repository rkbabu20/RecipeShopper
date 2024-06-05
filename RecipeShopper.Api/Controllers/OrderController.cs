using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.Api.Controllers.Requests.OrderRequests;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetAllOrdersQuery;
using RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Orders controller
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
   [Authorize]
    public class OrderController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion
        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}/all")]
        [ProducesResponseType(typeof(GetAllOrdersQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrders([FromRoute] string userId)
        {
            // Get all orders
            var result = await _mediator.Send(new GetAllOrdersQuery(userId)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Get specific Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(typeof(GetOrderQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] string orderId)
        {
            // Get all orders
            var result = await _mediator.Send(new GetOrderQuery(orderId)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Submit order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("submit")]
        [ProducesResponseType(typeof(SubmitOrderCommandResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> Submit([FromBody] SubmitOrderRequest submitRequest)
        {
            // Get all orders
            var submitOrderCommand = _mapper.Map<SubmitOrderCommand>(submitRequest);
            var result = await _mediator.Send(submitOrderCommand).ConfigureAwait(false);
            return GetObjectResult(result);
        }
    }
}
