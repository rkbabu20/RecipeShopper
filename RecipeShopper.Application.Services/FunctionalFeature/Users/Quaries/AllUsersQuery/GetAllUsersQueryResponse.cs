using RecipeShopper.Application.Services.Base;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Users.Quaries.AllUsersQuery
{
    /// <summary>
    /// Response for GetAllUsersQuery
    /// </summary>
    public class GetAllUsersQueryResponse : BaseResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAllUsersQueryResponse() => Users = new List<ViewUserDTO>();

        #region public properties
        public List<ViewUserDTO>? Users { get; set; }
        #endregion
    }
}
