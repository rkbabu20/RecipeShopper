using MediatR;
using RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand;
using RecipeShopper.CommandQuery.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.UpdateUserCommand
{
    /// <summary>
    /// Get all users query
    /// </summary>
    public class UpdateUserCommand(UserDTO userDto)
        : IRequest<UpdateUserCommandResponse>
    {
        public UserDTO User => userDto;
    }
}
