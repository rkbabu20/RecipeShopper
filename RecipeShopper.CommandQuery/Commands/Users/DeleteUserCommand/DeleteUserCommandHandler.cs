using AutoMapper;
using MediatR;
using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public DeleteUserCommandHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserCommandResponse();
            await _repositories.UsersRepository.DeleteAsync(new Domain.Aggregates.GenericRequest() { RequestId = request.UserId }).ConfigureAwait(false);
            var aggregate = await _repositories.UsersRepository.GetAsync(new Domain.Aggregates.GenericRequest() { RequestId = request.UserId }).ConfigureAwait(false);
            if (aggregate != null && aggregate.User ==null)
            {
                response.Status = Enums.StatusTypeEnum.Success;
            }
           else
            {
                response.Status = Enums.StatusTypeEnum.Failure;
            }
            return response;
        }
        #endregion
    }
}
