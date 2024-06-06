using RecipeShopper.Application.Services.Base;

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
