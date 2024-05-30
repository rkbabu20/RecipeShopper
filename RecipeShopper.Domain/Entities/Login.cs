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
    public class Login : DataProperties
    {
        public Login() { }
        /// <summary>Login id</summary>
        public Guid LoginId { get; set; }
        /// <summary>User</summary>
        public User User { get; set; }

    }
}
