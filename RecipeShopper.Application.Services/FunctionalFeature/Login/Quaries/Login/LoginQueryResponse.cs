using RecipeShopper.Application.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login
{
    /// <summary>
    /// Login query response
    /// </summary>
    public class LoginQueryResponse : BaseResponse
    {
        public string Token { get; set; }
    }
}
