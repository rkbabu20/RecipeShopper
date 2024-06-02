using RecipeShopper.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Extensions
{
    /// <summary>
    /// Base response extension
    /// </summary>
    public static class BaseResponseExtension
    {
        /// <summary>
        /// IsValid response
        /// </summary>
        /// <param name="response">BaseResponse</param>
        /// <returns>True : If response is valid</returns>
        public static bool IsValid(this BaseResponse response)
        {
            return response != null && response.Status == Enums.StatusTypeEnum.Success;
        }
    }
}
