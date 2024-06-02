using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery
{
    public class GetAllUsersResponse : BaseResponse
    {
        public GetAllUsersResponse() { }
        public List<ViewUserDTO>? Users { get; set; }
    }
}
