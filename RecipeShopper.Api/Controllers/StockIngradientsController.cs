using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests.StockIngradientsRequests;
using RecipeShopper.CommandQuery.Commands.StockIngradients.AddStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.DeleteStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.PatchStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.StockIngradients.UpdateStockIngradientCommand;
using RecipeShopper.CommandQuery.Commands.Users.AddUserCommand;
using RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand;
using RecipeShopper.CommandQuery.Commands.Users.UpdateUserCommand;
using RecipeShopper.CommandQuery.DTOs;
using RecipeShopper.CommandQuery.Quaries.StockIngradients.AllStockIngradients;
using RecipeShopper.CommandQuery.Quaries.StockIngradients.GetStockIngradient;
using RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.Controllers
{
    public class StockIngradientsController : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">IMediator</param>
        /// <param name="mapper">IMapper</param>
        public StockIngradientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }// UserController
        #endregion

        /// <summary>
        /// Get all ingradients
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            // Write logic to return all Ingradients
            var result = await _mediator.Send(new GetAllStockIngradientQuery()).ConfigureAwait(false);
            return GetObjectResult(result);
        }


        /// <summary>
        /// Get all ingradients
        /// </summary>
        /// <returns></returns>
        [HttpGet("{ingradientId}")]
        public async Task<IActionResult> Get([FromRoute]string ingradientId)
        {
            Guid ingradientIdGuid = Guid.Empty;
            if (!Guid.TryParse(ingradientId, out ingradientIdGuid))
            {
                return BadRequest();
            }
            // Query call using mediator
            var result = await _mediator.Send(new GetStockIngradientQuery(ingradientIdGuid)).ConfigureAwait(false);
            return GetObjectResult(result);
        }

        /// <summary>
        /// Delete ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{ingradientId}")]
        public async Task<IActionResult> Delete([FromRoute] string ingradientId)
        {
            // Delete the StockIngradient from DB
            Guid ingradientIdGuid = Guid.Empty;
            if (!Guid.TryParse(ingradientId, out ingradientIdGuid))
            {
                return BadRequest();
            }
            // Query call using mediator
            var result = await _mediator.Send(new DeleteStockIngradientCommand(ingradientIdGuid));
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] StockIngradientAddRequest request)
        {
            // Add user
            var stockIngradient = _mapper.Map<StockIngradientDTO>(request);
            stockIngradient.StockIngradientId = Guid.NewGuid();
            var result = await _mediator.Send(new AddStockIngradientCommand(stockIngradient));
            return GetObjectResult(result);
        }

        /// <summary>
        /// Update ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> replace([FromBody] StockIngradientUpdateRequest updateRequest)
        {
            // Upgrade ingradient
            var stockIngradientDto = _mapper.Map<StockIngradientDTO>(updateRequest);
            var result = await _mediator.Send(new UpdateStockIngradientCommand(stockIngradientDto));
            return GetObjectResult(result);
        }

        /// <summary>
        /// Update ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch("upatePartial")]
        public async Task<IActionResult> UpdatePartial([FromBody] StockIngradientPatchRequest patchRequest)
        {
            // Upgrade ingradient
            var updateCommand = _mapper.Map<PatchStockIngradientCommand>(patchRequest);
            var result = await _mediator.Send(updateCommand);
            return GetObjectResult(result);
        }
    }
}
