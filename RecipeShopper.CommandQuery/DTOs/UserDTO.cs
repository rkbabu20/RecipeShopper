using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.CommandQuery.Enums;

namespace RecipeShopper.CommandQuery.DTOs
{
    public class UserDTO
    {
        /// <summary>First name</summary>
        public string? FirstName { get; set; }
        /// <summary>Last name</summary>
        public string? LastName { get; set; }
        /// <summary>Login email</summary>
        public string? Email { get; set; }
        /// <summary>Login password</summary>
        public string? Password { get; set; }
        /// <summary>User Id</summary>
        public string? UserId { get; set; }
        /// <summary>User Id</summary>
        public UserRoleEnum Role { get; set; }
    }
}
