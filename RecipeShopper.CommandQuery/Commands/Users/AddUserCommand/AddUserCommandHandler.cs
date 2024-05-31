using AutoMapper;
using MediatR;
using RecipeShopper.Data.Contracts;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Commands.Users.AddUserCommand
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        public AddUserCommandHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        public async Task<AddUserCommandResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var response = new AddUserCommandResponse();
            UsersAggregate aggregate = new UsersAggregate(new User());
            await _repositories.UsersRepository.AddAsync(aggregate);
            response = _mapper.Map<AddUserCommandResponse>(aggregate);
            if (response != null && aggregate.IsUserAdded)
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
