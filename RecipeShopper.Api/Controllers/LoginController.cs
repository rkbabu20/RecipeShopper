﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.Application.Services.DTOs;
using RecipeShopper.Application.Services.FunctionalFeature.Cart.Commands.CartAddCommand;
using RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login;
using Swashbuckle.AspNetCore.Annotations;

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
        [ProducesResponseType(typeof(LoginQueryResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary ="User login Here", Description ="Users can login with their registered email and password.")]
        public async Task<IActionResult> Authentication([FromBody] AuthenticationRequest request)
        {
            var loginDto = _mapper.Map<LoginDTO>(request);
            var result = await _mediator.Send(new LoginQuery(loginDto)).ConfigureAwait(false);
            return GetObjectResult(result);
        }
    }
}
