using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Enums;
using System.Net;

namespace RecipeShopper.Api.Controllers.Base
{
    /// <summary>
    /// Base api controller for base
    /// </summary>
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {

        /// <summary>
        /// Create valid object result to output from response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ObjectResult GetObjectResult(BaseResponse response)
        {
            // Step 1 : Create object result
            ObjectResult result = new ObjectResult(response);

            if (response != null)
            {
                // Step 2 : Construct object result as per the message types
                if (response.Status == StatusTypeEnum.Success || response.Status == StatusTypeEnum.PartialSuccess)
                    result.StatusCode = (int)HttpStatusCode.OK;
                else if (response.Messages.Any())
                {
                    if (response.Messages.Exists(m => m.MessageType == MessageTypeEnum.NoResourceFoundError))
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                    else if (response.Messages.Exists(m => m.MessageType == MessageTypeEnum.ApplicationError))
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    else if (response.Messages.Exists(m => m.MessageType == MessageTypeEnum.ValidationError))
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            return result;
        }// End GetObjectResult
    }
}
