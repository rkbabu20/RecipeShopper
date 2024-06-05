using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Application.Services.Registrations
{
    /// <summary>
    /// MediatR Registration
    /// </summary>
    public static class MediatRRegistration
    {
        /// <summary>
        /// Register Mediat R
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterMediatR(this IServiceCollection services)
        {
            // Add Mediat R to dependencies
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
