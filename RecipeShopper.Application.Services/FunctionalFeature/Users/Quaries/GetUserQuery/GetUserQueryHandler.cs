using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.GetUserQuery
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class GetUserQueryHandler :
        BaseHandler<GetUserQuery, GetUserResponse>,
        IRequestHandler<GetUserQuery, GetUserResponse>
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
        /// <summary>
        /// Handle get user 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetUserResponse();
            try
            {
                // Step 1 : Validate request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Get user 
                    var usersAggregate = await _repositories.UsersRepository.GetAsync(_mapper.Map<GenericRequest>(request));
                    response = _mapper.Map<GetUserResponse>(usersAggregate);
                    // Step 3 : Check if user exists
                    if (response != null && response.User != null)
                        HandleMessage(response, "User retrieved successfully.");
                    else
                        HandleMessage(response, $"No user found for userid: {request.UserId}", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }// End Handle

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request">GetUserQuery</param>
        /// <param name="response">GetUserResponse</param>
        /// <returns></returns>
        protected async override Task Validate(GetUserQuery request, GetUserResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.UserId == Guid.Empty) { base.HandleMessage(response, $"Invalid user id passed {request.UserId}", Enums.MessageTypeEnum.ValidationError); }
        }// End Validate
        #endregion
    }
}
