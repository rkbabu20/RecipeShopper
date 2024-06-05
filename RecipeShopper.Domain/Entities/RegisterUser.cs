using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// User registration entity
    /// </summary>
    /// <param name="user"></param>
    /// <param name="rawPassword"></param>
    public class RegisterUser(User user, string rawPassword)
    {
        /// <summary>Raw password</summary>
        public string RawPassword { get; set; } = rawPassword;
        /// <summary>User</summary>
        public User User { get; set; } = user;
    }// End Register User
}
