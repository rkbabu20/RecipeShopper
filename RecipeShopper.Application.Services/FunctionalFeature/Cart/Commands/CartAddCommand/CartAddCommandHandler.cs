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
using RecipeShopper.Application.Services.DTOs;

namespace RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand
{
    /// <summary>
    /// Cart add handler
    /// </summary>
    /// <param name="repositories"></param>
    /// <param name="mapper"></param>
    public class CartAddCommandHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<CartAddCommand, CartAddCommandResponse>,
        IRequestHandler<CartAddCommand, CartAddCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion
        public async Task<CartAddCommandResponse> Handle(CartAddCommand request, CancellationToken cancellationToken)
        {
            var response = new CartAddCommandResponse();
            try
            {
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 1 : Prepare domain cart agreegate
                    var stockIngradients = await _repositories.StockIngradientRepository.GetAllAsync().ConfigureAwait(false);
                    var cartAggregate = new CartAggregate(_mapper.Map<DomainEntities.Cart>(request.Cart));
                    cartAggregate.Cart.PrepareCartForAdd(stockIngradients.StockIngradients);
                    await _repositories.CartRepository.AddAsync(cartAggregate).ConfigureAwait(false);

                    // Step 2 : Validate status and updae response with status and messages
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
        /// Validate
        /// </summary>
        /// <param name="request">CartAddCommand</param>
        /// <param name="response">CartAddCommandResponse</param>
        /// <returns></returns>
        protected async override Task Validate(CartAddCommand request, CartAddCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.Cart == null) { base.HandleMessage(response, "Cart is null and cannot be added.", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrWhiteSpace(request.Cart.UserId)) { base.HandleMessage(response, "UserId is null and cannot be added.", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                var existingCart = await _repositories.CartRepository.GetAsync(new Domain.Aggregates.GenericRequest() { Id = request.Cart.UserId });
                if (existingCart != null && existingCart.Cart != null)
                    base.HandleMessage(response, $"Cart already exists.", Enums.MessageTypeEnum.ValidationError);
            }
        }

    }
}
