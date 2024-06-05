using MediatR;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.DTOs.Base;
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
    /// <remarks>
    /// Constructor for Add User command
    /// </remarks>
    /// <param name="user"></param>
    public class AddUserCommand : BaseUserDTO, IRequest<AddUserCommandResponse>
    {
        /// <summary>
        /// Password
        /// </summary>
       public string Password { get; set; } 
    }
}
