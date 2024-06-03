using AutoMapper;
using MediatR;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.Extensions;
using DomainEntities = RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login
{
    /// <summary>
    /// Login query handler
    /// </summary>
    /// <param name="repositories">IRepositories</param>
    /// <param name="mapper">IMapper</param>
    public class LoginQueryHandler(IRepositories repositories, IMapper mapper) :
        BaseHandler<LoginQuery, LoginQueryResponse>,
        IRequestHandler<LoginQuery, LoginQueryResponse>
    {
        #region Private variables
        private readonly IRepositories _repositories = repositories;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region Interface login
        public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new LoginQueryResponse();
            try
            {
                // Step 1 : Validate the input
                await Validate(request, response).ConfigureAwait(false);
                if (response.IsValid())
                {
                    // Step 2 : Validate login credentials and generate jwt token
                    var loginAggregate = await _repositories.LoginRepository.ValidateAsync(_mapper.Map<DomainEntities.Login>(request.LogIn)).ConfigureAwait(false);
                    if (loginAggregate != null && loginAggregate.IsLoginSuccess)
                    {
                        response.Token = loginAggregate.Token!;
                        HandleMessage(response, "Login successful.");
                    }
                    else
                        HandleMessage(response, "Invalid email/password.");
                }
            }
            catch (Exception ex) { HandleException(response, ex); }
            return response;
        }
        #endregion

        #region abstract class logic
        protected async override Task Validate(LoginQuery request, LoginQueryResponse response)
        {
            if (request == null) { HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (request.LogIn == null) { HandleMessage(response, "Request cannot be null", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrWhiteSpace(request.LogIn.Email)) { HandleMessage(response, "Email missing in the request", Enums.MessageTypeEnum.ValidationError); }
            else if (string.IsNullOrWhiteSpace(request.LogIn.Password)) { HandleMessage(response, "Password missing in the request", Enums.MessageTypeEnum.ValidationError); }
            else
            {
                var userAggregate = await _repositories.UsersRepository.GetUserByEmailAsync(request.LogIn.Email!).ConfigureAwait(false);
                if (userAggregate != null && userAggregate.User == null)
                    HandleMessage(response, "Invalid email/password.", Enums.MessageTypeEnum.ValidationError);
            }
        }
        #endregion
    }
}
