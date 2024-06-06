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

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartDeleteIngradientCommand
{ 
    /// <summary>
    /// Delete ingradient command handler
    /// </summary>
    /// <param name="repositories"></param>
    /// <param name="mapper"></param>
    public class CartDeleteIngradientCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartDeleteIngradientCommand, CartDeleteIngradientCommandResponse>,
        IRequestHandler<CartDeleteIngradientCommand, CartDeleteIngradientCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        /// <summary>
        /// CartIngradient delete command
        /// </summary>
        /// <param name="request">CartDeleteIngradientCommand</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns></returns>
        public async Task<CartDeleteIngradientCommandResponse> Handle(CartDeleteIngradientCommand request, CancellationToken cancellationToken)
        {
            var response = new CartDeleteIngradientCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid() && Guid.TryParse(request.CartId, out var cartId) && Guid.TryParse(request.RecipeId, out var recipeId)  && Guid.TryParse(request.CartIngradientId, out var ingradientId))
                {
                    var cartAggregate = new CartAggregate(new CartIngradient());
                    await _repositories.CartRepository.DeleteIngradientFromCartRecipe(cartId, recipeId,ingradientId, cartAggregate).ConfigureAwait(false);
                    // Step 3 : Validate status and updae response with status and messages
                    if (cartAggregate.IsDeleted)
                        base.HandleMessage(response, $"Ingrdient deleted from cart successfully.");
                    else
                        base.HandleMessage(response, $"Ingrdient failed to delete from cart.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }// Handle

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="request">CartDeleteIngradientCommand</param>
        /// <param name="response">CartDeleteIngradientCommandResponse</param>
        /// <returns></returns>
        protected async override Task Validate(CartDeleteIngradientCommand request, CartDeleteIngradientCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartId, out _)) { base.HandleMessage(response, "Provide valid cart identifier.", Enums.MessageTypeEnum.ValidationError); }
            else if (!Guid.TryParse(request.CartIngradientId, out _)) { base.HandleMessage(response, "Provide valid ingradient identifier.", Enums.MessageTypeEnum.ValidationError); }
        }
    }
}
