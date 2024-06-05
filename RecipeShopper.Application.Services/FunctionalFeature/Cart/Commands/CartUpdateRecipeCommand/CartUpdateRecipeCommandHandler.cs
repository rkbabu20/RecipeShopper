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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateRecipeCommand
{ 
    public class CartUpdateRecipeCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartUpdateRecipeCommand, CartUpdateRecipeCommandResponse>,
        IRequestHandler<CartUpdateRecipeCommand, CartUpdateRecipeCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<CartUpdateRecipeCommandResponse> Handle(CartUpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = new CartUpdateRecipeCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid() && Guid.TryParse(request.CartId, out var cartId))
                {
                    // Prepare recipe for update
                    var cartAggregate = new CartAggregate(_mapper.Map<Recipe>(request.Recipe));
                    cartAggregate.Recipe.ApplyDateProperties(true, true);
                   
                    await _repositories.CartRepository.UpdateRecipeToCart(cartId, cartAggregate).ConfigureAwait(false);

                    // Step 3 : Validate status and updae response with status and messages
                    if (cartAggregate.IsUpdated)
                        base.HandleMessage(response, $"Recipe updated in cart.");
                    else
                        base.HandleMessage(response, $"Recipe update failed in cart.", Enums.MessageTypeEnum.ApplicationError);

                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(CartUpdateRecipeCommand request, CartUpdateRecipeCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Recipe == null) { base.HandleMessage(response, "Recipe is null and cannot be update.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
