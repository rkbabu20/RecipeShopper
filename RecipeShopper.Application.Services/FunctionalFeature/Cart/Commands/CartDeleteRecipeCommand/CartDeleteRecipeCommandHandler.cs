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
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteIngradientCommand;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteRecipeCommand
{ 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="repositories"></param>
    /// <param name="mapper"></param>
    public class CartDeleteRecipeCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartDeleteRecipeCommand, CartDeleteRecipeCommandResponse>,
        IRequestHandler<CartDeleteRecipeCommand, CartDeleteRecipeCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        /// <summary>
        /// Delete recipe from cart 
        /// </summary>
        /// <param name="request">CartDeleteRecipeCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<CartDeleteRecipeCommandResponse> Handle(CartDeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = new CartDeleteRecipeCommandResponse();
            try
            {
                // Step 1 : Validate 
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid() && Guid.TryParse(request.CartId, out var cartId) && Guid.TryParse(request.RecipeId, out var recipeId))
                {
                    // Step 2 : Delete recipe from cart
                    var cartAggregate = new CartAggregate(new CartIngradient());
                    await _repositories.CartRepository.DeleteRecipeFromCart(cartId, recipeId, cartAggregate).ConfigureAwait(false);
                    // Step 3 : Validate status and updae response with status and messages
                    if (cartAggregate.IsDeleted)
                        base.HandleMessage(response, $"Recipe deleted from cart successfully.");
                    else
                        base.HandleMessage(response, $"Recipe add to cart failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }// Handle

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request">CartDeleteRecipeCommand</param>
        /// <param name="response">CartDeleteRecipeCommandResponse</param>
        /// <returns></returns>
        protected async override Task Validate(CartDeleteRecipeCommand request, CartDeleteRecipeCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.RecipeId, out _)) { base.HandleMessage(response, "Provide valid recipe identifier.", Enums.MessageTypeEnum.ValidationError); }
        }// End CartDeleteRecipeCommandResponse
    }
}
