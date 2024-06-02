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
        public DeleteUserCommand(string id) { this.Id = id; }
        public string Id { get; private set; }
    }
}
