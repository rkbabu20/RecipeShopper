using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.UpdateUserCommand
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class UpdateUserCommand(UserDTO userDto)
        : IRequest<UpdateUserCommandResponse>
    {
        public UserDTO User { get; set; } = userDto;
    }
}
