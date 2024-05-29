using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class GetAllUsersQuery : IRequest<UsersResponse>
    {
        public GetAllUsersQuery() { }
    }
}
