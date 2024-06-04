﻿namespace RecipeShopper.Api.Controllers.Requests.CartRequests
{
    /// <summary>
    /// Cart add ingradient request
    /// </summary>
    public class CartAddIngradientRequest
    {
        /// <summary>User id</summary>
        public string? UserId { get; set; }
        /// <summary>Cart id</summary>
        public string? CartId { get; set;}
        /// <summary>Recipe id</summary>
        public string? RecipeId { get; set;}
        /// <summary>User id</summary>
        public CartIngradientRequest? Ingradient { get; set; }
    }
}
