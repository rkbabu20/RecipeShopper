namespace RecipeShopper.Api.Controllers.Requests
{
    /// <summary>
    /// Authenticatoin request
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>Login Email</summary>
        public string Email { get; set; }
        /// <summary>Login Password</summary>
        public string Password { get; set; }
    }
}
