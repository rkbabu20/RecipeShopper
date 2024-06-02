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

namespace RecipeShopper.Application.Services.FunctionalFeature.StockIngradients.Quaries.GetStockIngradient
{
    /// <summary>
    /// Get stock ingradiet query handler
    /// </summary>
    public class GetStockIngradientQueryHandler :
        BaseHandler<GetStockIngradientQuery, GetStockIngradientResponse>,
        IRequestHandler<GetStockIngradientQuery, GetStockIngradientResponse>
    {

        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion
        #region Constructor
        public GetStockIngradientQueryHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        public async Task<GetStockIngradientResponse> Handle(GetStockIngradientQuery request, CancellationToken cancellationToken)
        {
            var response = new GetStockIngradientResponse();
            try
            {
                // Step 1 : Validate request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Get StockIngradient 
                    var aggregate = await _repositories.StockIngradientRepository.GetAsync(_mapper.Map<GenericRequest>(request));
                    response = _mapper.Map<GetStockIngradientResponse>(aggregate);
                    // Step 3 : Check if StockIngradient exists
                    if (response != null && response.StockIngradient != null)
                        HandleMessage(response, "StockIngradient retrieved successfully.");
                    else
                        HandleMessage(response, $"No StockIngradient found for the Id: {request.StockIngradientId}", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request">GetStockIngradientQuery</param>
        /// <param name="response">GetStockIngradientResponse</param>
        /// <returns></returns>
        protected async override Task Validate(GetStockIngradientQuery request, GetStockIngradientResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.StockIngradientId == Guid.Empty) { base.HandleMessage(response, $"Invalid StockIngradientId passed {request.StockIngradientId}", Enums.MessageTypeEnum.ValidationError); }
        }// End Validate
    }
}
