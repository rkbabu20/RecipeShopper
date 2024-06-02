using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.DBContexts.AuthDbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace RecipeShopper.DBContexts.Registrations
{
    public static class AuthenticationRegistration
    {
        public static void CustomAuthenticationRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                // Add Identity
                //services.AddIdentity<User, IdentityRole>()
                //    .AddEntityFrameworkStores<ApplicationAuthDbContext>()
                //    .AddSignInManager()
                //    .AddRoles<IdentityRole>();

                //// Add JWT
                //services.AddAuthentication(options =>
                //{
                //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //}).AddJwtBearer(options =>
                //{
                //    options.TokenValidationParameters = new TokenValidationParameters()
                //    {
                //        ValidateIssuer = true,
                //        ValidateAudience = true,
                //        ValidateIssuerSigningKey = true,
                //        ValidateLifetime = true,
                //        ValidIssuer = configuration["jwt:Issuer"],
                //        ValidAudience = configuration["jwt:Audience"],
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]!))
                //    };
                //});
            }
        }
    }
}
