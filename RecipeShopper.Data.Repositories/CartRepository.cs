using Microsoft.EntityFrameworkCore;
using RecipeShopper.Application.Contracts;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.CartAggregate;
using RecipeShopper.Domain.Entities;
using RecipeShopper.Domain.Extensions;
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
        private RecipeShopperDbContext _dbContext { get; set; } = dbContext!;
        #endregion

        #region Cart actions
        /// <summary>
        /// Add cart 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddAsync(CartAggregate request)
        {
            if (request != null)
            {
                // Step 1 : Get existing cart and check there is no
                var existingCart = await GetAsync(new GenericRequest() { Id = request.Cart.UserId }).ConfigureAwait(false);
                if (existingCart == null|| (existingCart!=null && existingCart.Cart==null))
                {
                    // Step 2 : Total price
                    request.Cart.TotalPrice = request.Cart.GetTotalPrice();
                    AddCart(request.Cart);
                    // Step 4 :  Save changes
                    request.IsAdded = _dbContext.SaveChanges(true) > 0;
                }
                else
                {
                    request.ValidationErrors.Add("Thee is an existing cart hence new cart cannot be added.");
                }
            }
        }

        /// <summary>
        /// Delet cart from user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task DeleteAsync(GenericRequest request)
        {
            if (request != null)
            {
                var existingCart = await GetAsync(request).ConfigureAwait(false);
                if (existingCart != null && existingCart.Cart != null)
                {
                    RemoveCart(existingCart.Cart);
                    _dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CartAggregate> GetAsync(GenericRequest request)
        {
            CartAggregate aggregate = null;
            if (request != null)
            {
                if (!string.IsNullOrWhiteSpace(request.Id))
                {
                    var userCart = _dbContext.Cart
                        .Include(x => x.Recipes)
                        .ThenInclude(x => x.Ingradients)
                        .FirstOrDefault(x => x.UserId.Equals(request.Id) && x.OrderId==null);

                    aggregate = new CartAggregate(userCart);

                }
                else if (request.RequestId != Guid.Empty)
                {
                    var userCart = _dbContext.Cart
                         .Include(x => x.Recipes)
                        .ThenInclude(x => x.Ingradients)
                        .FirstOrDefault(x => x.CartId == request.RequestId && x.OrderId==null);

                    aggregate = new CartAggregate(userCart);
                }
            }
            return aggregate!;
        }

        /// <summary>
        /// Update cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateAsync(CartAggregate request)
        {

            if (request != null)
            {
                // Step 1 : Delete existing cart
                await DeleteAsync(new GenericRequest() { Id = request.Cart.UserId }).ConfigureAwait(false);
                // Step 2 : Add new cart
                await AddAsync(request).ConfigureAwait(false);

                // Step 3 : Reset the status
                request.IsUpdated = request.IsAdded;
            }

        }
        #endregion

        #region Recipe Actions
        /// <summary>
        /// Add recipe to cart
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <param name="request">Cart aggrigate</param>
        /// <returns></returns>
        public async Task AddRecipeToCart(Guid cartId, CartAggregate request)
        {
            if (cartId != Guid.Empty && request != null && request != null)
            {
                var cart = _dbContext.Cart.Include(x=>x.Recipes).ThenInclude(x=>x.Ingradients).FirstOrDefault(p => p.CartId == cartId);
                if (cart != null)
                {
                    // Add cart ingradient
                    cart.Recipes?.Add(request.Recipe);
                    AddRecipe(request.Recipe);
                    cart.TotalPrice = cart.GetTotalPrice();
                    // Save DB Changes
                    request.IsAdded = _dbContext.SaveChanges() > 0;
                }
            }
        }// End AddRecipeToCart

        /// <summary>
        /// Delete recipe from cart
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <param name="recipeId">Recipe Id</param>
        /// <param name="request">CartAggregate</param>
        /// <returns></returns>
        public async Task DeleteRecipeFromCart(Guid cartId, Guid recipeId, CartAggregate request)
        {
            // Step 1 : Get Cart
            var cart = _dbContext.Cart.Include(x => x.Recipes).ThenInclude(x => x.Ingradients).FirstOrDefault(x => x.CartId == cartId);
            if (cart != null)
            {
                // Step 2 : Find Recipe from cart
                var recipe = cart.Recipes?.FirstOrDefault(x => x.RecipeId == recipeId);
                // Step 3 : Delete the recipe from cart
                if (recipe != null)
                {
                    cart.Recipes?.Remove(recipe);
                    // Step 4 : Recalculate total price
                    cart.TotalPrice = cart.GetTotalPrice();
                    // Step 5 : SaveChanges
                    _dbContext.SaveChanges(true);
                }
            }
        }// End DeleteRecipeFromCart

        /// <summary>
        /// Update Recipe to cart
        /// </summary>
        /// <param name="cartId">Cart id</param>
        /// <param name="request">CartAggregate</param>
        /// <returns></returns>
        public async Task UpdateRecipeToCart(Guid cartId, CartAggregate request)
        {
            if (cartId != Guid.Empty && request != null)
            {
                // Step 1 : Delete recipe from cart
                await DeleteRecipeFromCart(cartId, request.Recipe.RecipeId, request);

                // Step 2 : Add recipe to cart
                await AddRecipeToCart(cartId, request);
            }
        }
        #endregion

        #region Cart Recipe Ingradient actions
        /// <summary>
        /// Add ingradients to cart recipe
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="recipeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddIngradientsToCartRecipe(Guid cartId, Guid recipeId, CartAggregate request)
        {
            if (cartId != Guid.Empty && recipeId != Guid.Empty && request != null && request.CartIngradient != null)
            {
                var cart = _dbContext.Cart.Include(x=>x.Recipes).ThenInclude(x=>x.Ingradients).First(p => p.CartId == cartId);
                if (cart != null)
                {
                    // Add cart ingradient
                    cart.Recipes.Find(p => p.RecipeId == recipeId).Ingradients.Add(request.CartIngradient);
                    cart.TotalPrice = cart.GetTotalPrice();
                    // Save DB Changes
                    request.IsAdded = _dbContext.SaveChanges() > 0;
                }
            }
        }// end AddIngradientsToCartRecipe

        /// <summary>
        /// Update ingradient in to cart recipe
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="recipeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateIngradientFromCartRecipe(Guid cartId, Guid recipeId, CartAggregate request)
        {
            // Step 1 : Delete ingradient from cart recipe
            await DeleteIngradientFromCartRecipe(cartId, recipeId, request.CartIngradient.StockIngradientId, request).ConfigureAwait(false);

            // Step 2 : Add ingradient to cart
            await AddIngradientsToCartRecipe(cartId, recipeId, request);

            // Step 4 : Update status
            request.IsUpdated = request.IsAdded;
        }

        /// <summary>
        /// Delete ingradients from Recipe
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <param name="recipeId">Recipe Id</param>
        /// <param name="cartIngradientId">Ingradient Id</param>
        /// <returns></returns>
        public async Task DeleteIngradientFromCartRecipe(Guid cartId, Guid recipeId, Guid cartIngradientId, CartAggregate request)
        {
            // Step 1 : Fetch Cart
            var cart = _dbContext.Cart?.Include(x=>x.Recipes).ThenInclude(x=>x.Ingradients).FirstOrDefault(x => x.CartId == cartId);
            if (cart != null)
            {
                // Step 2 : Fetch recipe
                var recipe = cart.Recipes?.FirstOrDefault(x => x.RecipeId == recipeId);
                if (recipe != null)
                {
                    //Step 3 : Fetch Ingradient
                    var cartIngradient = recipe.Ingradients?.FirstOrDefault(x => x.CartIngradientId == cartIngradientId);
                    if (cartIngradient != null)
                    {
                        //Step 4: Remove ingradient 
                        recipe.Ingradients?.Remove(cartIngradient);

                        // Step 5 : Update total price
                        cart.TotalPrice = cart.GetTotalPrice();
                        request.IsDeleted = _dbContext.SaveChanges() > 0;
                    }
                }
            }
        }
        #endregion
        #region Cascading logic to add Cart
        private void AddCart(Cart cart)
        {
            if(cart !=null)
            {
                foreach(var recipe in cart.Recipes)
                    AddRecipe(recipe);
                _dbContext.Cart.Add(cart);
            }
        }
        private void AddRecipe(Recipe recipe)
        {
            if(recipe != null)
            {
                foreach (var ingradient in recipe.Ingradients)
                    AddCartIngradient(ingradient);
                _dbContext.Recipes.Add(recipe);
            }
        }
        private void AddCartIngradient(CartIngradient cartIngradient)
        {
            _dbContext.CartIngradients.Add(cartIngradient);
        }
        #endregion

        #region Cascading logic to remove cart and its childs
        private void RemoveCart(Cart cart)
        {
            if (cart != null)
            {
                foreach (var recipe in cart.Recipes)
                    RemoveRecipe(recipe);
                _dbContext.Cart.Remove(cart);
            }
        }
        private void RemoveRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                foreach (var ingradient in recipe.Ingradients)
                    RemoveCartIngradient(ingradient);
                _dbContext.Recipes.Remove(recipe);
            }
        }
        private void RemoveCartIngradient(CartIngradient cartIngradient)
        {
            _dbContext.CartIngradients.Remove(cartIngradient);
        }
        #endregion
    }
}
