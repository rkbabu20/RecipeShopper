using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.AddUserCommand
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class AddUserCommand : IRequest<AddUserCommandResponse>
    {
        public AddUserCommand(UserDTO user) { User = user; }
        public UserDTO User { get; private set; }
    }
}
