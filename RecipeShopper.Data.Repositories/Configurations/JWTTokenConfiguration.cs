using Microsoft.Extensions.Configuration;
using RecipeShopper.Application.Contracts.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories.Configurations
{
    /// <summary>
    /// JWT Token configuratoins
    /// </summary>
    /// <param name="configuration"></param>
    public class JWTTokenConfiguration(IConfiguration configuration) : IJWTTokenConfiguration
    {
        /// <summary>Security key</summary>
        public string SecurityKey => configuration["JwtTokenConfiguration:SecurityKey"];
        /// <summary>Issuer</summary>
        public string Issuer => configuration["JwtTokenConfiguration:Issuer"];
        /// <summary>Audience</summary>
        public string Audience => configuration["JwtTokenConfiguration:Audience"];
    }
}
