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

namespace RecipeShopper.Application.Services.FunctionalFeature.Orders.Commands.SubmitOrderCommand
{
    public class SubmitOrderCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<SubmitOrderCommand, SubmitOrderCommandResponse>,
        IRequestHandler<SubmitOrderCommand, SubmitOrderCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<SubmitOrderCommandResponse> Handle(SubmitOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new SubmitOrderCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid() && Guid.TryParse(request.CartId, out var cartId))
                {
                    // Step 1 : Get Cart
                    var cartAggregate = await _repositories.CartRepository.GetAsync(new Domain.Aggregates.GenericRequest() { RequestId = cartId });
                    if (cartAggregate != null && cartAggregate.Cart != null)
                    {
                        // Step 2 : construct Order entity
                        var orderAggregate = new OrdersAggregate(new DomainEntities.Order()
                        {
                            User = cartAggregate.Cart.User,
                            Recipes = cartAggregate.Cart.Recipes,
                            CreateDate = cartAggregate.Cart.CreateDate,
                            OrderId = Guid.NewGuid()
                        });
                        // Step 3 : Submit order
                        await _repositories.OrdersRepository.SubmitAsync(orderAggregate).ConfigureAwait(false);
                        // Step 4 : Check status
                        if (orderAggregate.IsAdded)
                        {
                           base.HandleMessage(response, "Order submitted successfully.");
                        }
                        else
                            base.HandleMessage(response, "Order submission failed.", Enums.MessageTypeEnum.ApplicationError);
                    }
                    else
                        base.HandleMessage(response, "Cart not found. Order cannot be submitted.", Enums.MessageTypeEnum.ValidationError);

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
        /// <returns></returns>
        protected async override Task Validate(SubmitOrderCommand request, SubmitOrderCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrWhiteSpace(request.UserId)) { base.HandleMessage(response, "Provide valid useridentifier", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrWhiteSpace(request.CartId)) { base.HandleMessage(response, "Provide valid cart identifier", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out var cartId)) { base.HandleMessage(response, "Provide valid cart identifier", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
