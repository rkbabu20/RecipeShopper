using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.DeleteStockIngradientCommand
{
    /// <summary>
    /// Delete stock ingradient handler
    /// </summary>
    public class DeleteStockIngradientCommandHandler
        : BaseHandler<DeleteStockIngradientCommand, DeleteStockIngradientCommandResponse>,
        IRequestHandler<DeleteStockIngradientCommand, DeleteStockIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public DeleteStockIngradientCommandHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        /// <summary>
        /// Handle delete command
        /// </summary>
        /// <param name="request">DeleteStockIngradientCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<DeleteStockIngradientCommandResponse> Handle(DeleteStockIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteStockIngradientCommandResponse();
            try
            {
                // Step 1 : Validate the input
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2: Delete the stock ingradient from db
                    await _repositories.StockIngradientRepository.DeleteAsync(_mapper.Map<GenericRequest>(request)).ConfigureAwait(false);
                    // Step 3: Get the stock ingradient to validate if deleted
                    var aggregate = await _repositories.StockIngradientRepository.GetAsync(_mapper.Map<GenericRequest>(request)).ConfigureAwait(false);
                    // Step 4: Add response messages for succes or failure
                    if (aggregate != null && aggregate.StockIngradient == null)
                        HandleMessage(response, "StockIngradient deleted successfully.");
                    else
                        HandleMessage(response, "StockIngradient deletion failed", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request">DeleteStockIngradientCommand</param>
        /// <param name="response">DeleteStockIngradientCommandResponse</param>
        protected async override Task Validate(DeleteStockIngradientCommand request, DeleteStockIngradientCommandResponse response)
        {
            if (request == null)
                HandleMessage(response, "Request cannot be null.", Enums.MessageTypeEnum.ValidationError);
            else if (request.StockIngradientId == Guid.Empty)
                HandleMessage(response, $"Invalid StockIngradientId passed {request.StockIngradientId}", Enums.MessageTypeEnum.ValidationError);
            else
            {
                // Check if stockingradient exists to update
                var existingStockIngradientAggregate = await _repositories.StockIngradientRepository.GetAsync(_mapper.Map<GenericRequest>(request));
                if (existingStockIngradientAggregate.StockIngradient == null)
                    HandleMessage(response, $"StockIngradient not found for the id : {request.StockIngradientId}.Hence cannot be deleted.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
