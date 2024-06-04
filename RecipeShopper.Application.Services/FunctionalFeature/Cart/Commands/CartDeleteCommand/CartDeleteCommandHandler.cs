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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteCommand
{ 
    public class CartDeleteCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartDeleteCommand, CartDeleteCommandResponse>,
        IRequestHandler<CartDeleteCommand, CartDeleteCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<CartDeleteCommandResponse> Handle(CartDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new CartDeleteCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if(response.IsValid() && Guid.TryParse(request.CartId,out var cartId))
                {
                    var aggregate = _repositories.CartRepository.DeleteAsync(new Domain.Aggregates.GenericRequest() { RequestId = cartId });
                    base.HandleMessage(response, $"Cart deleted successfully.");
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(CartDeleteCommand request, CartDeleteCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.UserId)) { base.HandleMessage(response, "Provide valid user identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
