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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddIngradientCommand
{ 
    /// <summary>
    /// Cart add ingradient command handler
    /// </summary>
    /// <param name="repositories">Repositories</param>
    /// <param name="mapper">Mapper</param>
    public class CartAddIngradientCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartAddIngradientCommand, CartAddIngradientCommandResponse>,
        IRequestHandler<CartAddIngradientCommand, CartAddIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        /// <summary>
        /// Handle cart add ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CartAddIngradientCommandResponse> Handle(CartAddIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new CartAddIngradientCommandResponse();
            try
            {
                // Step 1 : Validate
                await Validate(request, response).ConfigureAwait(false);
                if(response.IsValid() && Guid.TryParse(request.CartId, out var cartId) && Guid.TryParse(request.RecipeId, out var recipeId)) 
                {
                    // Step 2 : Prepare cart aggrigate
                    var cartAggregate = new CartAggregate(_mapper.Map<CartIngradient>(request.Ingradient));
                    cartAggregate.CartIngradient.ApplyDateProperties(true, false);
                    cartAggregate.CartIngradient.CartIngradientId = Guid.NewGuid();
                    // Step 3 : Add ingradients to cart recipe
                    await _repositories.CartRepository.AddIngradientsToCartRecipe(cartId, recipeId, cartAggregate).ConfigureAwait(false);
                    // Step 4 : Validate status and updae response with status and messages
                    if (!cartAggregate.ValidationErrors.Any() || cartAggregate.IsAdded)
                        base.HandleMessage(response, $"Cart added successfully.");
                    else
                    {
                        base.HandleMessage(response, $"Cart add failed.", Enums.MessageTypeEnum.ApplicationError);
                        cartAggregate.ValidationErrors.ForEach(error => base.HandleMessage(response, error, Enums.MessageTypeEnum.ValidationError));
                    }
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected async override Task Validate(CartAddIngradientCommand request, CartAddIngradientCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Ingradient == null) { base.HandleMessage(response, "Cartingradient cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Ingradient.StockIngradientId == Guid.Empty) { base.HandleMessage(response, "Cartingradient should have valid StockIngradientId", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrEmpty(request.UserId)) { base.HandleMessage(response, "Provide valid user identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.RecipeId, out _)) { base.HandleMessage(response, "Provide valid Recipe identifier.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
