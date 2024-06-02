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

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.AllStockIngradients
{
    /// <summary>
    /// Get all stock ingradiet query handler
    /// </summary>
    public class GetAllStockIngradientQueryHandler :
        BaseHandler<GetAllStockIngradientQuery, GetAllStockIngradientResponse>,
        IRequestHandler<GetAllStockIngradientQuery, GetAllStockIngradientResponse>
    {

        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public GetAllStockIngradientQueryHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        public async Task<GetAllStockIngradientResponse> Handle(GetAllStockIngradientQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllStockIngradientResponse();
            try
            {
                // Step 1 : Validate request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Get StockIngradients
                    var aggregate = await _repositories.StockIngradientRepository.GetAllAsync().ConfigureAwait(false);
                    response = _mapper.Map<GetAllStockIngradientResponse>(aggregate);
                    // Step 3 : Check if StockIngradients exists
                    if (response != null && response.StockIngradients != null && response.StockIngradients.Any())
                        HandleMessage(response, "StockIngradients retrieved successfully.");
                    else
                        HandleMessage(response, $"No StockIngradients found.", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request">GetAllStockIngradientQuery</param>
        /// <param name="response">GetAllStockIngradientResponse</param>
        /// <returns></returns>
        protected async override Task Validate(GetAllStockIngradientQuery request, GetAllStockIngradientResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
        }// End Validate
    }
}
