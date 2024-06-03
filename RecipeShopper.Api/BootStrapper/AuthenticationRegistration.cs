using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.Application.Contracts.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RecipeShopper.DBContexts.Registrations
{
    public static class AuthenticationRegistration
    {
        /// <summary>
        /// Authentication registration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void CustomAuthenticationRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                // Add Identity
                services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<RecipeShopperDbContext>()
                    .AddSignInManager()
                    .AddRoles<IdentityRole>();

                // Add JWT
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JwtTokenConfiguration:Issuer"],
                        ValidAudience = configuration["JwtTokenConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenConfiguration:SecurityKey"]!))
                    };
                });
            }
        }
    }
}
