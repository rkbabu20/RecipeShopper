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
using Microsoft.IdentityModel.Tokens;

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Quaries.GetOrderQuery
{ 
    public class CartAddRecipeCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<GetOrderQuery, GetOrderQueryResponse>,
        IRequestHandler<GetOrderQuery, GetOrderQueryResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<GetOrderQueryResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var response = new GetOrderQueryResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if(response.IsValid())
                {
                   if(Guid.TryParse(request.OrderId, out var orderId))
                    {
                        var ordersAggregate = await _repositories.OrdersRepository.GetAsync(new Domain.Aggregates.GenericRequest() { RequestId= orderId }).ConfigureAwait(false);
                        if (ordersAggregate != null && ordersAggregate.Order != null)
                        {
                            
                            base.HandleMessage(response, $"Order retrived successfully.: {request.OrderId}.");
                        }
                        else
                           base.HandleMessage(response, $"Order not found for the orderid : {request.OrderId}.", Enums.MessageTypeEnum.NoResourceFoundError);
                    }
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(GetOrderQuery request, GetOrderQueryResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.OrderId)) { base.HandleMessage(response, "Empty order id passed.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.OrderId, out _)) { base.HandleMessage(response, "Invalid order id.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
