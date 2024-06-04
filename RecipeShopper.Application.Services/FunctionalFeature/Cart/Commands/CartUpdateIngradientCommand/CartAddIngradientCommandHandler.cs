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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand
{ 
    public class CartUpdateIngradientCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartUpdateIngradientCommand, CartUpdateIngradientCommandResponse>,
        IRequestHandler<CartUpdateIngradientCommand, CartUpdateIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<CartUpdateIngradientCommandResponse> Handle(CartUpdateIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new CartUpdateIngradientCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if(response.IsValid())
                {
                    // Step 1 : Prepare domain cart add request
                   // var cartAggregate = new CartAggregate(_mapper.Map<DomainEntities.Cart>(request.Cart));
                   // Step 2 : Add request to db
                   // Step 3 : Validate status and updae response with status and messages
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(CartUpdateIngradientCommand request, CartUpdateIngradientCommandResponse response)
        {
            //if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            //else if (request.Cart == null) { base.HandleMessage(response, "Cart is null and cannot be added.", Enums.MessageTypeEnum.ValidationError); }
            //else if(request.Cart.User== null) { base.HandleMessage(response, "User is null and cannot be added.", Enums.MessageTypeEnum.ValidationError); }
            //else
            //{
            //    var existingCart = await _repositories.CartRepository.GetAsync(new Domain.Aggregates.GenericRequest() { Id = request.Cart?.User!.Id! }); ;
            //    if (existingCart != null && existingCart.Cart!=null)
            //        base.HandleMessage(response, $"Cart already exists.", Enums.MessageTypeEnum.ValidationError);
            //}
        }
    }
}
