using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;

namespace RecipeShopper.Api.Controllers
{
    public class IngradientController : BaseController
    {
        /// <summary>
        /// Get all ingradients
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllIngradients()
        {
            // Write logic to return all Ingradients
            var result = new { IsSuucess = "true", Message = "Get all ingradients" };
            return Ok(result);
        }

        /// <summary>
        /// Delete ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            // Delete ingradient
            var result = new { IsSuucess = "true", Message = "Delete ingradient" };
            return Ok(result);
        }

        /// <summary>
        /// Add ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] IngradientAddRequest request)
        {
            // Add ingradient
            var result = new { IsSuucess = "true", Message = "Add ingradient" };
            return Ok(result);
        }

        /// <summary>
        /// Update ingradient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upate")]
        public async Task<IActionResult> Update([FromBody] IngradientUpdateRequest updateRequest)
        {
            // Upgrade ingradient
            var result = new { IsSuucess = "true", Message = "Update ingradient" };
            return Ok(result);
        }
    }
}
