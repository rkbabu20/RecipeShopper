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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddRecipeCommand
{ 
    public class CartAddRecipeCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartAddRecipeCommand, CartAddRecipeCommandResponse>,
        IRequestHandler<CartAddRecipeCommand, CartAddRecipeCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<CartAddRecipeCommandResponse> Handle(CartAddRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = new CartAddRecipeCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if(response.IsValid() && Guid.TryParse(request.CartId, out var cartId))
                {
                    // Setp 1 : Prepare recipe for add
                    var recipe = _mapper.Map<Recipe>(request.Recipe);
                    recipe.ApplyDateProperties(true, false);
                    var cartAggregate = new CartAggregate(recipe);
                    await _repositories.CartRepository.AddRecipeToCart(cartId, cartAggregate).ConfigureAwait(false);
                    // Step 3 : Validate status and updae response with status and messages
                    if (cartAggregate.IsAdded)
                        base.HandleMessage(response, $"Recipe added to cart successfully.");
                    else
                        base.HandleMessage(response, $"Recipe add to cart failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(CartAddRecipeCommand request, CartAddRecipeCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Recipe == null) { base.HandleMessage(response, "Recipe cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.UserId)) { base.HandleMessage(response, "Provide valid user identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
