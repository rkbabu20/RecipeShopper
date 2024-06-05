using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Contracts.BaseContracts;
using RecipeShopper.Application.Contracts.Configurations;
using RecipeShopper.Domain.Aggregates;
using RecipeShopper.Domain.Aggregates.LoginAggregate;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories
{
    /// <summary>
    /// Login repository
    /// </summary>
    public class LoginRepository(UserManager<User> userManager, IJWTTokenConfiguration jwtTokenConfiguration) : ILoginRepository
    {
        #region Private variables
        private readonly UserManager<User> _userManager = userManager;
        #endregion

        #region Interface Logic
        /// <summary>
        /// Vakudate login
        /// </summary>
        /// <param name="request">Login request</param>
        /// <returns>LogInAggregate</returns>
        public async Task<LogInAggregate> ValidateAsync(Login request)
        {
            var loginAggregate = new LogInAggregate() { IsLoginSuccess = false };
            // Step 1 : Find user
            var user = await _userManager.FindByEmailAsync(request.Email!).ConfigureAwait(false);
            if (user != null)
            {
                // Step 2 : Validate user password
                if (await _userManager.CheckPasswordAsync(user, request.Password).ConfigureAwait(false))
                {
                    // Step 3 : If login success then generate token
                    loginAggregate.IsLoginSuccess = true;
                    loginAggregate.Token = GenerateToken(user);
                }
            }
            return loginAggregate;
        }
        #endregion

        #region Private members
        private string GenerateToken(User user)
        {
            var jwtSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfiguration.SecurityKey));
            var signCredentials = new SigningCredentials(jwtSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                        issuer: jwtTokenConfiguration.Issuer,
                        audience: jwtTokenConfiguration.Audience,
                        claims: ConstructUserClaims(user).ToArray(),
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signCredentials
                        );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private List<Claim> ConstructUserClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };
        }
        #endregion
    }
}
