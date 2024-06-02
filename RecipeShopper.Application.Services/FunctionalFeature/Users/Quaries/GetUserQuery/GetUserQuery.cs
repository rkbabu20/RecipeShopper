using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.GetUserQuery
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class GetUserQuery(string userId) : IRequest<GetUserResponse>
    {
        public string Id { get; set; } = userId;
    }
}
