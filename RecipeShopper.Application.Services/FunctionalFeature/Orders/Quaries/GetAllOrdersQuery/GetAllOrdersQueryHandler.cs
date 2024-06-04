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
using RecipeShopper.Domain.Aggregates.OrdersAggrigate;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetAllOrdersQuery
{
    public class GetAllOrdersQueryHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<GetAllOrdersQuery, GetAllOrdersQueryResponse>,
        IRequestHandler<GetAllOrdersQuery, GetAllOrdersQueryResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        
        /// <summary>
        /// Handle get all orders query handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllOrdersQueryResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 1 : Get orders
                    var ordersAggregate = await _repositories.OrdersRepository.GetAllAsync(new Domain.Aggregates.GenericRequest() { Id = request.UserId });
                    if (ordersAggregate != null && ordersAggregate.Orders != null && ordersAggregate.Orders.Any())
                        base.HandleMessage(response, "Order retrieved successfully.");
                    else
                        base.HandleMessage(response, "No orders found", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }// Handle

        protected async override Task Validate(GetAllOrdersQuery request, GetAllOrdersQueryResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.UserId)) { base.HandleMessage(response, "Provide valid useridentifier", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
