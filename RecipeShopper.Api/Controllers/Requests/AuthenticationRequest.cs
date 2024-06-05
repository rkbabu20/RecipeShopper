using System.ComponentModel.DataAnnotations;

namespace RecipeShopper.Api.Controllers.Requests
{
    /// <summary>
    /// Authenticatoin request
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>Login Email</summary>
        [Required]
        public string Email { get; set; }
        /// <summary>Login Password</summary>
        [Required]
        public string Password { get; set; }
    }
}
