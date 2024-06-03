using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// Login
    /// </summary>
    public class Login
    {
        /// <summary>Email</summary>
        public string?  Email { get; set; }
        /// <summary>Password</summary>
        public string? Password { get; set; }

    }
}
