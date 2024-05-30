using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.AddUserCommand
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class AddUserCommand : IRequest<AddUserCommandResponse>
    {
        public AddUserCommand(Guid userId) { this.UserId = userId; }
        public Guid UserId { get; private set; }
    }
}
