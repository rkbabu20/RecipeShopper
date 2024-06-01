using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.CommandQuery.Base;
using System.Net;

namespace RecipeShopper.Api.Controllers.Base
{
    /// <summary>
    /// Base api controller for base
    /// </summary>
    [ApiController]
    //[Authorize]
    [Produces("application/json")]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {

        /// <summary>
        /// To result
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ObjectResult GetObjectResult(BaseResponse response)
        {
            ObjectResult result = new ObjectResult(response);

            if (response != null)
            {
                if (response.Status == CommandQuery.Enums.StatusTypeEnum.Success || response.Status == CommandQuery.Enums.StatusTypeEnum.PartialSuccess)
                    result.StatusCode = (int)HttpStatusCode.OK;
                else if (response.Messages.Any())
                {
                    if (response.Messages.Exists(m => m.MessageType == CommandQuery.Enums.MessageTypeEnum.NoResourceFoundError))
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                    else if (response.Messages.Exists(m => m.MessageType == CommandQuery.Enums.MessageTypeEnum.ApplicationError))
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    else if (response.Messages.Exists(m => m.MessageType == CommandQuery.Enums.MessageTypeEnum.ValidationError))
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            return result;
        }
    }
}
