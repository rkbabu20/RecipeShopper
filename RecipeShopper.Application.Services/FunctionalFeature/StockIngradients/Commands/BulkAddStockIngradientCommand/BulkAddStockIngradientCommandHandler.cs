using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.BulkAddStockIngradientCommand
{
    /// <summary>
    /// AddStockIngradientCommand handler
    /// </summary>
    public class BulkAddStockIngradientCommandHandler(IRepositories repositories, IMapper mapper)
                : BaseHandler<BulkAddStockIngradientCommand, BulkAddStockIngradientCommandResponse>,
        IRequestHandler<BulkAddStockIngradientCommand, BulkAddStockIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Interface methods
        /// <summary>
        /// Master list of ingradients - Add logic
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BulkAddStockIngradientCommandResponse> Handle(BulkAddStockIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new BulkAddStockIngradientCommandResponse();
            try
            {
                // Step 1 : Validate the request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Add StockIngradient
                    var aggregate = new StockIngradientsAggrigate(_mapper.Map<List<StockIngradient>>(request.StockIngradients));
                    aggregate.StockIngradients?.ForEach(sIng => sIng.ApplyDateProperties(true, false));
                    await _repositories.StockIngradientRepository.BulkAddAsync(aggregate).ConfigureAwait(false);

                    // Step 3 : Check if StockIngradient really added
                    if (response != null && aggregate.IsAdded)
                        HandleMessage(response, "StockIngradient added sucessfully.");
                    else HandleMessage(response!, "StockIngradient add failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request">AddStockIngradientCommand</param>
        /// <param name="response">AddStockIngradientCommandResponse</param>
        /// <returns></returns>
        protected async override Task Validate(BulkAddStockIngradientCommand request, BulkAddStockIngradientCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.StockIngradients == null || !request.StockIngradients.Any()) 
                { base.HandleMessage(response, "StockIngradient cannot be be null.", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                var existingStockIngradients = await _repositories.StockIngradientRepository.GetAllAsync();
                if (existingStockIngradients != null && existingStockIngradients.StockIngradients != null && existingStockIngradients.StockIngradients.Any())
                {
                    // Check for duplicates
                    var matchedIngradients = from eIng in existingStockIngradients.StockIngradients // Stock ingradients from database
                                             join nIng in request.StockIngradients  //Stock ingradients uploaded
                                             on eIng.Name equals nIng.Name // Join them with the name. If any item has same name in both the collections then it is duplicate
                                             select nIng.Name;

                    if (matchedIngradients != null && matchedIngradients.Any())
                        base.HandleMessage(response, $"Following stock ingradients are duplicates hence cannot be added. {string.Join(',', matchedIngradients.ToArray())}.", Enums.MessageTypeEnum.ValidationError);
                }// End If condition
            }
        }
        #endregion
    }
}
