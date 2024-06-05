using RecipeShopper.Application.Contracts.BaseContracts;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts
{
    /// <summary>
    /// Cart repository interface
    /// </summary>
    public interface ICartRepository : IAsynRepository<GenericRequest, CartAggregate>, ICreateUpdateAsyncRepository<CartAggregate>
    {
        #region Recipe cart actions
        Task AddRecipeToCart(Guid cartId, CartAggregate request);
        Task DeleteRecipeFromCart(Guid cartId,Guid recipeId,CartAggregate request);
        Task UpdateRecipeToCart(Guid cartId, CartAggregate request);
        #endregion

        #region Ingradient cart actions
        Task AddIngradientsToCartRecipe(Guid cartId,Guid recipeId, CartAggregate request);
        Task DeleteIngradientFromCartRecipe(Guid cartId, Guid recipeId,Guid cartIngradientId, CartAggregate request);
        Task UpdateIngradientFromCartRecipe(Guid cartId, Guid recipeId, CartAggregate request);
        #endregion
    }
}
