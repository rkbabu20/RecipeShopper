using AutoMapper;
using MediatR;
using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users
{
    /// <summary>
    /// Get all users query handler
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UsersResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion
        #region Constructor
        public GetAllUsersQueryHandler(IRepositories repositories, IMapper mapper) 
        { 
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        public async Task<UsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new UsersResponse();
            var usersAggregate = await _repositories.UsersRepository.GetAll().ConfigureAwait(false);
            response = _mapper.Map<UsersResponse>(usersAggregate);
            return response;
        }
        #endregion
    }
}
