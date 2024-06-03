using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    public class LoginController(IMediator mediator, IMapper mapper) : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;
        #endregion
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            var loginDto = _mapper.Map<LoginDTO>(request);
            var result = await _mediator.Send(new LoginQuery(loginDto)).ConfigureAwait(false);
            return GetObjectResult(result);
        }
    }
}
