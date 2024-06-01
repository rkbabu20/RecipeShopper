using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests
{
    /// <summary>
    /// Update user request
    /// </summary>
    public class UserUpdateRequest : BaseUser
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }
    }
}
