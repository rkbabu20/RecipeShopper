using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.DTOs
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginDTO 
    {
        public LoginDTO() { }
        /// <summary>Login id</summary>
        public string Email { get; set; }
        /// <summary>Password</summary>
        public string Password { get; set; }

    }
}
