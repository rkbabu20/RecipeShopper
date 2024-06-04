using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates.IngradientsAggregate;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Commands.AddStockIngradientCommand
{
    /// <summary>
    /// AddStockIngradientCommand handler
    /// </summary>
    public class AddStockIngradientCommandHandler(IRepositories repositories, IMapper mapper)
                : BaseHandler<AddStockIngradientCommand, AddStockIngradientCommandResponse>,
        IRequestHandler<AddStockIngradientCommand, AddStockIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Interface methods
        public async Task<AddStockIngradientCommandResponse> Handle(AddStockIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new AddStockIngradientCommandResponse();
            try
            {
                // Step 1 : Validate the request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Add StockIngradient
                    var aggregate = new StockIngradientsAggrigate(_mapper.Map<StockIngradient>(request.StockIngradient));
                    await _repositories.StockIngradientRepository.AddAsync(aggregate).ConfigureAwait(false);

                    // Step 3 : Check if StockIngradient really added
                    if (response != null && aggregate.IsAdded)
                        HandleMessage(response, "StockIngradient added sucessfully.");
                    else HandleMessage(response!, "StockIngradient add failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(AddStockIngradientCommand request, AddStockIngradientCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.StockIngradient == null) { base.HandleMessage(response, "StockIngradient cannot be be null.", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                var existingStockIngradient = await _repositories.StockIngradientRepository.GetByNameAsync(request.StockIngradient.Name);
                if (existingStockIngradient != null && existingStockIngradient.StockIngradient != null)
                    base.HandleMessage(response, $"StockIngradient already exists with the given Name {request.StockIngradient.Name}.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
