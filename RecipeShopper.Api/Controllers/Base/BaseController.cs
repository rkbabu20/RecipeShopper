using Microsoft.AspNetCore.Mvc;

namespace RecipeShopper.Api.Controllers.Base
{
    /// <summary>
    /// Base api controller for base
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
    }
}
