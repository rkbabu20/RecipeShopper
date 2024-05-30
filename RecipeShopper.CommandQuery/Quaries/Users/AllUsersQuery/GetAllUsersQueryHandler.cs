using AutoMapper;
using MediatR;
using RecipeShopper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery
{
    /// <summary>
    /// Get all users query handler
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
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
        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllUsersResponse();
            var usersAggregate = await _repositories.UsersRepository.GetAllAsync().ConfigureAwait(false);
            response = _mapper.Map<GetAllUsersResponse>(usersAggregate);
            if (response != null && response.Users.Any())
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
