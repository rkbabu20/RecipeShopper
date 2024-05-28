using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    public class LoginController : BaseController
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
       public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            // Authenticatoin logic goes here
            var result = new { IsSuucess="true", Message="Your login success" };
            return Ok(result);
        }
    }
}
