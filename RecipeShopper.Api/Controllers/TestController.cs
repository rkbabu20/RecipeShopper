using Microsoft.AspNetCore.Mvc;
using RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery;

namespace RecipeShopper.Api.Controllers
{
    public class TestController : ControllerBase
    {

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            Data.Data d = new Data.Data();
            // Query call using mediator
            var result = d.GetData();
            return Ok(result);
        }

    }
}
