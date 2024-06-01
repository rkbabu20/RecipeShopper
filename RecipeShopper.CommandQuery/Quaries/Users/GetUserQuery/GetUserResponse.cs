using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery
{
    /// <summary>
    /// Get user response
    /// </summary>
    public class GetUserResponse : BaseResponse
    {
        /// <summary>
        /// Get user response
        /// </summary>
        public GetUserResponse() { }

        /// <summary>User</summary>
        public ViewUserDTO? User { get; set; }
    }
}
