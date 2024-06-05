using AutoMapper;
using MediatR;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;


namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.AddUserCommand
{
    /// <summary>
    /// User command handler
    /// </summary>
    public class AddUserCommandHandler
        : BaseHandler<AddUserCommand, AddUserCommandResponse>,
        IRequestHandler<AddUserCommand, AddUserCommandResponse>
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
        /// <summary>
        /// Handle add user command response
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AddUserCommandResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var response = new AddUserCommandResponse();
            try
            {
                // Step 1 : Validate the request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Add user
                    var user = _mapper.Map<User>(request);
                    UsersAggregate aggregate = new UsersAggregate(new RegisterUser(user, request.Password!));
                    await _repositories.UsersRepository.AddAsync(aggregate).ConfigureAwait(false);

                    // Step 3 : Check if user really added
                    if (response != null && aggregate.IsAdded)
                        HandleMessage(response, "User added sucessfully.");
                    else HandleMessage(response!, "User add failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }// End 

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected async override Task Validate(AddUserCommand request, AddUserCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
                        else
            {
                if (string.IsNullOrWhiteSpace(request.FirstName)) { base.HandleMessage(response, "User first name is missing.", Enums.MessageTypeEnum.ValidationError); }
                if (string.IsNullOrWhiteSpace(request.LastName)) { base.HandleMessage(response, "User last name is missing.", Enums.MessageTypeEnum.ValidationError); }
                if (string.IsNullOrWhiteSpace(request.Email)) { base.HandleMessage(response, "User email is missing.", Enums.MessageTypeEnum.ValidationError); }
                else if ((await _repositories.UsersRepository.GetUserByEmailAsync(request.Email).ConfigureAwait(false)).User != null)
                    base.HandleMessage(response, $"User already exists with the given email {request.Email}.", Enums.MessageTypeEnum.ValidationError);
                if (string.IsNullOrWhiteSpace(request.Password)) { base.HandleMessage(response, "User password is missing.", Enums.MessageTypeEnum.ValidationError); }
                if (request.Role == Enums.RegisterUserRoleEnum.Unspecified) { base.HandleMessage(response, "User role is missing.", Enums.MessageTypeEnum.ValidationError); }
            }
        }
        #endregion
    }
}
