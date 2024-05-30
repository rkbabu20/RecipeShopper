using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class GetUserQuery(Guid userId) : IRequest<GetUserResponse>
    {
        public Guid UserId => userId;
    }
}
