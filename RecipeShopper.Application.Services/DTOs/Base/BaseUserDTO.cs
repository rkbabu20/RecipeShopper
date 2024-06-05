using RecipeShopper.Application.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.DTOs.Base
{
    /// <summary>
    /// Base user DTO
    /// </summary>
    public class BaseUserDTO
    {
        /// <summary>User Id</summary>
        public string? Id { get; set; }
        /// <summary>First name</summary>
        public string? FirstName { get; set; }
        /// <summary>Last name</summary>
        public string? LastName { get; set; }
        /// <summary>Login email</summary>
        public string? Email { get; set; }

        /// <summary>User Role</summary>
        public RegisterUserRoleEnum Role { get; set; }
    }// End BaseUserDTO
}// End BaseUserDTO
