using System.ComponentModel.DataAnnotations;
using RecipeShopper.Api.Controllers.Requests.Enums;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    /// <summary>
    /// Base User
    /// </summary>
    public class BaseUser
    {
       
        [Required]
        public string? FirstName { get; set; }
        /// <summary>Last name</summary>
        [Required]
        public string? LastName { get; set; }
        /// <summary>Email</summary>
        [Required]
        public string? Email { get; set; }
        [Required]
        public CustomerUserRoleEnum Role { get; set; }

    }
}
