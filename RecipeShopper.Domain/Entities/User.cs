using Microsoft.AspNetCore.Identity;
using RecipeShopper.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Domain.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>First name</summary>
        public string? FirstName { get; set; }
        /// <summary>Last name</summary>
        public string? LastName { get; set; }
        /// <summary>User Role</summary>
        public UserRoleEnum Role { get; set; }
    }// End user
}// End namespace
