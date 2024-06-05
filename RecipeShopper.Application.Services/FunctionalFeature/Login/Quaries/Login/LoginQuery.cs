using MediatR;
using RecipeShopper.Application.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.FunctionalFeature.Login.Quaries.Login
{
    /// <summary>
    /// Login query 
    /// </summary>
    /// <param name="email">Email</param>
    /// <param name="password">Password</param>
    public class LoginQuery(LoginDTO login) : IRequest<LoginQueryResponse>
    {
        /// <summary>Login</summary>
        public LoginDTO LogIn { get; set; } = login;
    }
}
