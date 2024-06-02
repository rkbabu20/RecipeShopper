using System;
using System.Collections.Generic;
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
        public string LoginId { get; set; }
        /// <summary>User</summary>
        public UserDTO User { get; set; }

    }
}
