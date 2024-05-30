using AutoMapper;
using MediatR;
using RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand;
using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.UpdateUserCommand
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class UpdateUserCommandHandler(IRepositories repositories, IMapper mapper) : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Interface methods implemented
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();
            return response;
        }
        #endregion
    }
}
