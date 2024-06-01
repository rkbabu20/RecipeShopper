using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeShopper.Api.Controllers.Base;
using RecipeShopper.Api.Controllers.Requests;
using RecipeShopper.CommandQuery.Commands.Users.AddUserCommand;
using RecipeShopper.CommandQuery.Commands.Users.DeleteUserCommand;
using RecipeShopper.CommandQuery.Commands.Users.UpdateUserCommand;
using RecipeShopper.CommandQuery.DTOs;
using RecipeShopper.CommandQuery.Quaries.Users.AllUsersQuery;
using RecipeShopper.CommandQuery.Quaries.Users.GetUserQuery;

namespace RecipeShopper.Api.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController : BaseController
    {
        #region private variables
        private readonly IMediator _mediator = null;
        private readonly IMapper _mapper = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">IMediator</param>
        /// <param name="mapper">IMapper</param>
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }// UserController
        #endregion

        #region Controller methods
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllUsers()
        {
            // Query call using mediator
            var result = await _mediator.Send(new GetAllUsersQuery());
            return GetObjectResult(result);
        }


        /// <summary>
        /// Get specific user based on userid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            // write logic to return user for specified email
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                return BadRequest();
            }
            // Query call using mediator
            var result = await _mediator.Send(new GetUserQuery(userIdGuid));
            return GetObjectResult(result);
        }


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] string userId)
        {
            // Delete the user from DB
            // write logic to return user for specified email
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                return BadRequest();
            }
            // Query call using mediator
            var result = await _mediator.Send(new DeleteUserCommand(userIdGuid));
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserAddRequest request)
        {
            // Add user
            var user = _mapper.Map<UserDTO>(request);
            user.UserId = Guid.NewGuid();
            var result = await _mediator.Send(new AddUserCommand(user));
            return GetObjectResult(result);
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("upate")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest updateRequest)
        {
            var user = _mapper.Map<UserDTO>(updateRequest);
            var result = await _mediator.Send(new UpdateUserCommand(user));
            return GetObjectResult(result);
        }
        #endregion
    }
}
