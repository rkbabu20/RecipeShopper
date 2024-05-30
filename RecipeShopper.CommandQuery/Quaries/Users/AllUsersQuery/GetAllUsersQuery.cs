using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class GetAllUsersQuery : IRequest<GetAllUsersResponse>
    {
        public GetAllUsersQuery() { }
    }
}
