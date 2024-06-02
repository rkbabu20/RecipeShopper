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
                    UsersAggregate aggregate = new UsersAggregate(_mapper.Map<User>(request.User));
                    await _repositories.UsersRepository.AddAsync(aggregate).ConfigureAwait(false);

                    // Step 3 : Check if user really added
                    if (response != null && aggregate.IsAdded)
                        HandleMessage(response, "User added sucessfully.");
                    else HandleMessage(response!, "User add failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        protected async override Task Validate(AddUserCommand request, AddUserCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.User == null) { base.HandleMessage(response, "User cannot be be null.", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                var userAggregate = await _repositories.UsersRepository.GetUserByEmailAsync(request.User.Email);
                if (userAggregate != null && userAggregate.User != null)
                    base.HandleMessage(response, $"User already exists with the given email {request.User.Email}.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
