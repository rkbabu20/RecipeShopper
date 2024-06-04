using Microsoft.EntityFrameworkCore;
using RecipeShopper.Application.Contracts;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Cart repository
    /// </summary>
    public class CartRepository(RecipeShopperDbContext dbContext) : ICartRepository
    {
        #region Private variables
        private RecipeShopperDbContext _dbContext { get; set; } = dbContext;
        #endregion

        public async Task AddAsync(CartAggregate request)
        {
            if (request != null)
            {
                // Step 1 : Get existing cart and check there is no
                var existingCart = await GetAsync(new GenericRequest() { Id = request.Cart.User!.Id }).ConfigureAwait(false);
                if (existingCart == null)
                {
                    _dbContext.Cart?.AddAsync(request.Cart);
                    // Save changes
                    request.IsAdded  =_dbContext.SaveChanges()>0;
                }
                else
                {
                    request.ValidationErrors.Add("Thee is an existing cart hence new cart cannot be added.");
                }
            }
        }

        public async Task AddIngradientsToCartRecipe(Guid cartId, Guid recipeId, CartAggregate request)
        {
            if(cartId != Guid.Empty && recipeId!= Guid.Empty && request !=null && request.CartIngradient != null)
            {
                var cart = _dbContext.Cart.First(p => p.CartId == cartId);
                if(cart != null)
                {
                    // Add cart ingradient
                    cart.Recipes.Find(p => p.RecipeId == recipeId).Ingradients.Add(request.CartIngradient);
                    // Save DB Changes
                    request.IsAdded = _dbContext.SaveChanges()>0;
                }
            }
        }

        public async Task AddRecipeToCart(Guid cartId, CartAggregate request)
        {
            if (cartId != Guid.Empty && request != null && request != null)
            {
                var cart = _dbContext.Cart.First(p => p.CartId == cartId);
                if (cart != null)
                {
                    // Add cart ingradient
                    cart.Recipes?.Add(request.Recipe);
                    // Save DB Changes
                    request.IsAdded = _dbContext.SaveChanges() > 0;
                }
            }
        }

        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null)
            {
                var existingCart = await GetAsync(request).ConfigureAwait(false);
                if (existingCart != null && existingCart.Cart != null && !existingCart.Cart.IsOrderComplete)
                {
                    var stockIngradients = _dbContext.StockIngradients.ToList();
                    var cartIngradients = existingCart.Cart.Recipes!.SelectMany(recipe => recipe.Ingradients!.ToList()).ToList();
                    if (stockIngradients.Any())
                        stockIngradients.ForEach(ing => ing.AvailableQuantity = ing.AvailableQuantity + cartIngradients.Find(ci => ci.StockIngradientId == ing.StockIngradientId).OrderedQuantity);

                    _dbContext.Cart.Remove(existingCart.Cart);
                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task DeleteIngradientFromCartRecipe(Guid cartId, Guid recipeId, Guid cartIngradientId)
        {
            var ingradient = _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.FirstOrDefault(x => x.RecipeId == recipeId).Ingradients?.FirstOrDefault(x => x.CartIngradientId == cartIngradientId);
            _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.FirstOrDefault(x => x.RecipeId == recipeId).Ingradients?.Remove(ingradient);
        }

        public Task DeleteIngradientFromCartRecipe(Guid cartId, Guid recipeId, Guid cartIngradientId, CartAggregate request)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecipeFromCart(Guid cartId, Guid recipeId, CartAggregate request)
        {
            var recipe = _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.FirstOrDefault(x => x.RecipeId == recipeId);
            _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.Remove(recipe);
        }

        public async Task<CartAggregate> GetAsync(GenericRequest request)
        {
            CartAggregate aggregate = null;
            if (request != null)
            {
                var cart = !string.IsNullOrWhiteSpace(request.Id) ? _dbContext.Cart.First(x => x.User!.Id.Equals(request.Id)) : ((request.RequestId != Guid.Empty) ? _dbContext.Cart.First(x => x.CartId == request.RequestId) : null);
                aggregate = new CartAggregate(cart);
            }
            return aggregate!;
        }

        public Task UpdateAsync(CartAggregate request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateIngradientFromCartRecipe(Guid cartId, Guid recipeId, CartAggregate request)
        {
            var recipe = _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.FirstOrDefault(x => x.RecipeId == recipeId);
            var ingradient = _dbContext.Cart?.FirstOrDefault(x => x.CartId == cartId).Recipes?.FirstOrDefault(x => x.RecipeId == recipeId).Ingradients?.FirstOrDefault(x => x.CartIngradientId == request.CartIngradient.CartIngradientId);
            recipe.Ingradients.Remove(ingradient);
            _dbContext.SaveChanges();
            recipe.Ingradients.Add(request.CartIngradient);
            _dbContext.SaveChanges(true);
        }
    }
}
