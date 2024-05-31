using AutoMapper;
using MediatR;
using RecipeShopper.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = null;
        private readonly IMapper _mapper = null;
        #endregion
        #region Constructor
        public GetUserQueryHandler(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        #endregion

        #region Interface methods
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUserResponse();
            var usersAggregate = await _repositories.UsersRepository.GetAsync(new Domain.Aggregates.GenericRequest() { RequestId = request.UserId });
            response = _mapper.Map<GetUserResponse>(usersAggregate);
            if (response != null && response.User !=null)
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
