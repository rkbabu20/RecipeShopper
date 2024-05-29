using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users
{
    public class UsersResponse : BaseResponse
    {
        public UsersResponse() { }
        public List<UserDTO>? Users { get; set; }
    }
}
