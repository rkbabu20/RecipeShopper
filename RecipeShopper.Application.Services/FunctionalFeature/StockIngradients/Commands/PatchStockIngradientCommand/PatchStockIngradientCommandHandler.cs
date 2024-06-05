using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.PatchStockIngradientCommand
{
    /// <summary>
    /// Patch command handler
    /// </summary>
    public class PatchStockIngradientCommandHandler :
        BaseHandler<PatchStockIngradientCommand, PatchStockIngradientCommandResponse>,
        IRequestHandler<PatchStockIngradientCommand, PatchStockIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public PatchStockIngradientCommandHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        /// <summary>
        /// Handle patch command
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PatchStockIngradientCommandResponse> Handle(PatchStockIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new PatchStockIngradientCommandResponse();
            try
            {
                // Step 1 : Validate the input
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    var aggregate = new StockIngradientsAggrigate(_mapper.Map<StockIngradient>(request));
                    // Step 2:  Update stock ingradient to db
                    await _repositories.StockIngradientRepository.Patch(aggregate);

                    // Step 4: Add response messages for succes or failure
                    if (aggregate != null && aggregate.IsPatched)
                        HandleMessage(response, "StockIngradient patched successfully.");
                    else
                        HandleMessage(response, "StockIngradient patch failed", Enums.MessageTypeEnum.ApplicationError);
                }

            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        protected async override Task Validate(PatchStockIngradientCommand request, PatchStockIngradientCommandResponse response)
        {
            if (request == null) HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError);
            else if (request.StockIngradientId == Guid.Empty) HandleMessage(response, $"Invalid user id passed {request.StockIngradientId}", Enums.MessageTypeEnum.ValidationError);
            else
            {
                // Check if user exists to update
                var existingAggregate = await _repositories.StockIngradientRepository.GetAsync(new GenericRequest() { RequestId = request.StockIngradientId }).ConfigureAwait(false);
                if (existingAggregate.StockIngradient == null)
                    HandleMessage(response, $"User not found for the user id : {request.StockIngradientId}.Hence cannot be deleted.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
