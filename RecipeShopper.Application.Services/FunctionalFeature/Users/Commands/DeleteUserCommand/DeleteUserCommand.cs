using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.DeleteUserCommand
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class DeleteUserCommand : IRequest<DeleteUserCommandResponse>
    {
        public DeleteUserCommand(Guid userId) { this.UserId = userId; }
        public Guid UserId { get; private set; }
    }
}
