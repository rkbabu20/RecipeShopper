using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;

namespace RecipeShopper.Api.Controllers
{
    public class CartController : BaseController
    {

        /// <summary>
        /// Get specific user cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            // write logic to return user cart
            var result = new { IsSuucess = "true", Message = "Get user cart" };
            return Ok(result);
        }

        /// <summary>
        /// Delete whole cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            // Delete the cart from DB
            var result = new { IsSuucess = "true", Message = "User cart deleted" };
            return Ok(result);
        }

        /// <summary>
        /// Add ingradients to cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CartAddRequest request)
        {
            // Add ingradients to cart
            var result = new { IsSuucess = "true", Message = "Ingradient added" };
            return Ok(result);
        }

        /// <summary>
        /// Update cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upate")]
        public async Task<IActionResult> Update([FromBody] CartUpdateRequest request)
        {
            // Update whole cart
            var result = new { IsSuucess = "true", Message = "Ingradient updated" };
            return Ok(result);
        }
    }
}
