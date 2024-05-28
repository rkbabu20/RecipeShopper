using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;

namespace RecipeShopper.Api.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllUsers()
        {
            // Write logic to return all users
            var result = new { IsSuucess = "true", Message = "Get all users" };
            return Ok(result);
        }


        /// <summary>
        /// Get specific user based on userid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute]string userid)
        {
            // write logic to return user for specified email
            var result = new { IsSuucess = "true", Message = "User retrieved" };
            return Ok(result);
        }


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            // Delete the user from DB
            var result = new { IsSuucess = "true", Message = "User Deleted" };
            return Ok(result);
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserAddRequest request)
        {
            // Delete the user from DB
            var result = new { IsSuucess = "true", Message = "User added" };
            return Ok(result);
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("upate")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest updateRequest)
        {
            // Delete the user from DB
            var result = new { IsSuucess = "true", Message = "User updated" };
            return Ok(result);
        }

    }
}
