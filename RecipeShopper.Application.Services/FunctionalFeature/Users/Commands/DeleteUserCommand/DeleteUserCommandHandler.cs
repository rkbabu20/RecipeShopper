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

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.DeleteUserCommand
{
    /// <summary>
    /// Delete user command handler
    /// </summary>
    public class DeleteUserCommandHandler
        : BaseHandler<DeleteUserCommand, DeleteUserCommandResponse>,
        IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
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
        /// <summary>
        /// Handle delete command
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteUserCommandResponse();
            try
            {
                // Step 1 : Validate the input
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2: Delete the user from db
                    await _repositories.UsersRepository.DeleteAsync(new Domain.Aggregates.GenericRequest() { RequestId = request.UserId }).ConfigureAwait(false);
                    // Step 3: Get user to validate if user deleted
                    var aggregate = await _repositories.UsersRepository.GetAsync(new Domain.Aggregates.GenericRequest() { RequestId = request.UserId }).ConfigureAwait(false);
                    // Step 4: Add response messages for succes or failure
                    if (aggregate != null && aggregate.User == null)
                        HandleMessage(response, "User deleted successfully.");
                    else
                        HandleMessage(response, "User deletion failed", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        protected async override Task Validate(DeleteUserCommand request, DeleteUserCommandResponse response)
        {
            if (request == null)
                HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError);
            else if (request.UserId == Guid.Empty)
                HandleMessage(response, $"Invalid user id passed {request.UserId}", Enums.MessageTypeEnum.ValidationError);
            else
            {
                // Check if user exists to update
                var existingUserAggregate = await _repositories.UsersRepository.GetAsync(_mapper.Map<GenericRequest>(request));
                if (existingUserAggregate.User == null)
                    HandleMessage(response, $"User not found for the user id : {request.UserId}.Hence cannot be deleted.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
