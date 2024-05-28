using System.ComponentModel.DataAnnotations;
using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests
{
    /// <summary>
    /// Add user request
    /// </summary>
    public class UserAddRequest : BaseUser
    {
        /// <summary>
        /// user password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
