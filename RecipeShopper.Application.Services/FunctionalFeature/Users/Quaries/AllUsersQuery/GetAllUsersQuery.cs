using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class GetAllUsersQuery : IRequest<GetAllUsersQueryResponse>
    {
        public GetAllUsersQuery() { }
    }
}
