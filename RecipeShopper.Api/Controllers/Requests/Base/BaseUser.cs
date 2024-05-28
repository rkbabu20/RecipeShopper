using System.ComponentModel.DataAnnotations;
using RecipeShopper.Api.Controllers.Requests.Enums;

namespace RecipeShopper.Api.Controllers.Requests.Base
{
    public class BaseUser
    {
        public string UserId { get; set; }
        /// <summary>First name</summary>
        [Required]
        public string? FirstName { get; set; }
        /// <summary>Last name</summary>
        [Required]
        public string? LastName { get; set; }
        /// <summary>Email</summary>
        [Required]
        public string? Email { get; set; }
        public UserRoleEnum Role { get; set; }

    }
}
