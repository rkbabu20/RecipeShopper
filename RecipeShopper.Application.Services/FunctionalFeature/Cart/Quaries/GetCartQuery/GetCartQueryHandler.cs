using AutoMapper;
using Azure;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using DomainEntities = RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.Domain.Entities;
using RecipeShopper.Application.Services.DTOs;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Quaries.GetCartQuery
{
    /// <summary>
    /// Get Cart Query Handler
    /// </summary>
    /// <param name="repositories">IRepositories</param>
    /// <param name="mapper">IMapper</param>
    public class GetCartQueryHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<GetCartQuery, GetCartQueryResponse>,
        IRequestHandler<GetCartQuery, GetCartQueryResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Handler
        /// <summary>
        /// Get cart query handler
        /// </summary>
        /// <param name="request">GetCartQuery</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<GetCartQueryResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCartQueryResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 1 : get cart
                    var cartAggregate = await _repositories.CartRepository.GetAsync(new Domain.Aggregates.GenericRequest(){ Id = request.UserId }).ConfigureAwait(false);
                    // Step 2 : Prepare response
                    if (cartAggregate != null && cartAggregate.Cart != null)
                    {
                        response = _mapper.Map<GetCartQueryResponse>(cartAggregate);
                        base.HandleMessage(response, $"Cart retrieved successfully.");
                    }
                    else base.HandleMessage(response, $"No cart found for the given userid {request.UserId}.", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }
        #endregion

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request">GetCartQuery</param>
        /// <param name="response">GetCartQueryResponse</param>
        /// <returns></returns>
        protected async override Task Validate(GetCartQuery request, GetCartQueryResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.UserId)) { base.HandleMessage(response, "Valid UserId to be passed to retrieve cart.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
