using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using RecipeShopper.Domain.Aggregates.UsersAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Commands.UpdateUserCommand
{
    /// <summary>
    /// Get Get users query handler
    /// </summary>
    public class UpdateUserCommandHandler(IRepositories repositories, IMapper mapper)
        : BaseHandler<UpdateUserCommand, UpdateUserCommandResponse>,
        IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Interface methods implemented
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandResponse();
            try
            {
                // Step 1 : Validate the request
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Check if user exists to update 
                    UsersAggregate aggregate = new UsersAggregate(_mapper.Map<User>(request.User));
                    await _repositories.UsersRepository.UpdateAsync(aggregate).ConfigureAwait(false);

                    // Step 3 : Check if user really updated
                    if (response != null && aggregate.IsUpdated)
                        HandleMessage(response, "User updated sucessfully.");
                    else HandleMessage(response!, "User updated failed.", Enums.MessageTypeEnum.ApplicationError);
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response!;
        }

        protected async override Task Validate(UpdateUserCommand request, UpdateUserCommandResponse response)
        {
            if (request == null) { base.HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.User == null) { base.HandleMessage(response, "User cannot be be null.", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                // Check if user exists to update
                var existingUserAggregate = await _repositories.UsersRepository.GetAsync(new Domain.Aggregates.GenericRequest() { Id = request.User.Id! });
                if (existingUserAggregate.User == null)
                    HandleMessage(response, $"User not found for the user id : {request.User.Id}. Hence cannot be updated.", Enums.MessageTypeEnum.ValidationError);
            }
            #endregion
        }
    }
}
