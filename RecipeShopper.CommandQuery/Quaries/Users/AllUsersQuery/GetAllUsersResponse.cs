using RecipeShopper.CommandQuery.Base;
using RecipeShopper.CommandQuery.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery
{
    public class GetAllUsersResponse : BaseResponse
    {
        public GetAllUsersResponse() { }
        public List<ViewUserDTO>? Users { get; set; }
    }
}
