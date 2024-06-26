﻿using RecipeShopper.Api.Controllers.Requests.Base;

namespace RecipeShopper.Api.Controllers.Requests.UserRequests
{
    /// <summary>
    /// Update user request
    /// </summary>
    public class UserUpdateRequest : BaseUser
    {
        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
    }
}
