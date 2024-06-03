using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Contracts.Configurations
{
    public interface IJWTTokenConfiguration
    {
        string SecurityKey { get; }
        string Issuer { get; }
        string Audience { get; }

    }
}
