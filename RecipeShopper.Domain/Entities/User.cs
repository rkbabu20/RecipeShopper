﻿using RecipeShopper.Domain.Enums;
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
    public class User : DataProperties
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
    }// End user
}// End namespace
