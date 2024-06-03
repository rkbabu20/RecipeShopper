using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;

namespace RecipeShopper.Api.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}/all")]
        public async Task<IActionResult> GetAllOrders([FromRoute] string userId)
        {
            // Write logic to return all users
            var result = new { IsSuucess = "true", Message = "All orders" };
            return Ok(result);
        }

        ///// <summary>
        ///// Get specific Order
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[HttpGet("{orderId}")]
        //public async Task<IActionResult> Get([FromRoute] string orderId)
        //{
        //    // Get specific order
        //    var result = new { IsSuucess = "true", Message = "Order retrieved" };
        //    return Ok(result);
        //}

        /// <summary>
        /// Submit order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{userId}/submit")]
        public async Task<IActionResult> Submit([FromRoute] string userId)
        {
            // Submit order logic
            var result = new { IsSuucess = "true", Message = "Order submitted" };
            return Ok(result);
        }
    }
}
