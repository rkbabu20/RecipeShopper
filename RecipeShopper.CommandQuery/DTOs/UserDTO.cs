using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.CommandQuery.DTOs.Base;
using RecipeShopper.CommandQuery.Enums;

namespace RecipeShopper.CommandQuery.DTOs
{
    /// <summary>
    /// User DTO
    /// </summary>
    public class UserDTO : BaseUserDTO
    {
        /// <summary>Login password</summary>
        public string? Password { get; set; }
    }
}
