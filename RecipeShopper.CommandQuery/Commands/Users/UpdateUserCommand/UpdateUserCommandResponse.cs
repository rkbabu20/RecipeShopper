﻿using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand
{
    /// <summary>
    /// Get user response
    /// </summary>
    public class UpdateUserCommandResponse : BaseResponse
    {
        /// <summary>
        /// Get user response
        /// </summary>
        public UpdateUserCommandResponse() { }

        /// <summary>User</summary>
        public UserDTO? User { get; set; }
    }
}