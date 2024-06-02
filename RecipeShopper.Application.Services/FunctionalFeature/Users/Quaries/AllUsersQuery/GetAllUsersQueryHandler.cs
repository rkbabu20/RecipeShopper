using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;


namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery
{
    /// <summary>
    /// Get all users query handler
    /// </summary>
    public class GetAllUsersQueryHandler :
        BaseHandler<GetAllUsersQuery, GetAllUsersResponse>,
        IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
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
            try
            {
                // Step 1 : Validate
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2: Get all users
                    var usersAggregate = await _repositories.UsersRepository.GetAllAsync().ConfigureAwait(false);
                    response = _mapper.Map<GetAllUsersResponse>(usersAggregate);
                    // Step 3 : Handle messages
                    if (response != null && response.Users!.Any())
                        HandleMessage(response!, "Users retrieved successfully.");
                    else
                        HandleMessage(response!, "No users found.", Enums.MessageTypeEnum.NoResourceFoundError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response!;
        }

        protected async override Task Validate(GetAllUsersQuery request, GetAllUsersResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
        }
        #endregion
    }
}
