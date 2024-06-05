using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.Configurations
{
    /// <summary>
    /// JWT Token configuration
    /// </summary>
    public interface IJWTTokenConfiguration
    {
        /// <summary>Security token</summary>
        string SecurityKey { get; }
        /// <summary>Issuer</summary>
        string Issuer { get; }
        /// <summary>Audiance</summary>
        string Audience { get; }
    }
}
