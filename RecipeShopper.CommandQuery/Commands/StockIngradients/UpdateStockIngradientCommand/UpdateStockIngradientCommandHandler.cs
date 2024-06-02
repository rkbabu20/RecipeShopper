using AutoMapper;
using MediatR;
using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.Extensions;
using RecipeShopper.Data.Contracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.StockIngradients.UpdateStockIngradientCommand
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class DeleteUserCommandHandler
        : BaseHandler<UpdateStockIngradientCommand, UpdateStockIngradientCommandResponse>,
        IRequestHandler<UpdateStockIngradientCommand, UpdateStockIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public DeleteUserCommandHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        /// <summary>
        /// Handle delete command
        /// </summary>
        /// <param name="request">UpdateStockIngradientCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<UpdateStockIngradientCommandResponse> Handle(UpdateStockIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStockIngradientCommandResponse();
            try
            {
                // Step 1 : Validate the input
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    var aggregate = new StockIngradientsAggrigate(_mapper.Map<StockIngradient>(request.StockIngradient));
                    // Step 2:  Update stock ingradient to db
                    await _repositories.StockIngradientRepository.UpdateAsync(aggregate);
                  
                    // Step 4: Add response messages for succes or failure
                    if (aggregate != null && aggregate.IsUpdated)
                        HandleMessage(response, "StockIngradient updated successfully.");
                    else
                        HandleMessage(response, "StockIngradient update failed", Enums.MessageTypeEnum.ApplicationError);
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
        protected async override Task Validate(UpdateStockIngradientCommand request, UpdateStockIngradientCommandResponse response)
        {
            if (request == null || request.StockIngradient == null)
                HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError);
            else if (request.StockIngradient.StockIngradientId == Guid.Empty)
                HandleMessage(response, $"Invalid stockingradientid passed {request.StockIngradient.StockIngradientId}", Enums.MessageTypeEnum.ValidationError);
            else
            {
                // Check if stockingradient exists to update
                var existingAggregate = await _repositories.StockIngradientRepository.GetAsync(new GenericRequest() { RequestId = request.StockIngradient.StockIngradientId });
                if (existingAggregate.StockIngradient == null)
                    HandleMessage(response, $"Stock ingradient not found for ingradientId : {request.StockIngradient.StockIngradientId}.Hence cannot be updated.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
