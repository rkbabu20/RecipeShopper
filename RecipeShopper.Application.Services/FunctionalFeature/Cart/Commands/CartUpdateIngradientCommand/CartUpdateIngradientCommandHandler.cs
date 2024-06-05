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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartUpdateIngradientCommand
{ 
    /// <summary>
    /// Handle logic for cartingradient update
    /// </summary>
    /// <param name="repositories"></param>
    /// <param name="mapper"></param>
    public class CartUpdateIngradientCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartUpdateIngradientCommand, CartUpdateIngradientCommandResponse>,
        IRequestHandler<CartUpdateIngradientCommand, CartUpdateIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        /// <summary>
        /// CartIngradient update to recipe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CartUpdateIngradientCommandResponse> Handle(CartUpdateIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new CartUpdateIngradientCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid() && Guid.TryParse(request.CartId, out var cartId) && Guid.TryParse(request.RecipeId, out var recipeId))
                {
                    // Step 1 : Create cart aggregate fpr Ingradient update
                    var cartAggregate = new CartAggregate(_mapper.Map<CartIngradient>(request.Ingradient));
                    cartAggregate.CartIngradient.ApplyDateProperties(true, true);
                    // Step 2 : 
                    await _repositories.CartRepository.UpdateIngradientFromCartRecipe(cartId, recipeId, cartAggregate).ConfigureAwait(false);
                    // Step 3 : Validate status and updae response with status and messages
                    if (cartAggregate.IsUpdated)
                        base.HandleMessage(response, $"Ingradient updated in cart recipe.");
                    else
                        base.HandleMessage(response, $"Ingradient update failed in cart recipe.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request">CartUpdateIngradientCommand</param>
        /// <param name="response">CartUpdateIngradientCommandResponse</param>
        /// <returns></returns>
        protected async override Task Validate(CartUpdateIngradientCommand request, CartUpdateIngradientCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.RecipeId, out _)) { base.HandleMessage(response, "Provide valid recipe identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Ingradient == null) { base.HandleMessage(response, "Ingradient to update should be non null value", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Ingradient.StockIngradientId == Guid.Empty) { base.HandleMessage(response, "Ingradient should have valid StockIngradientId.", Enums.MessageTypeEnum.ValidationError); }

        }
    }
}
