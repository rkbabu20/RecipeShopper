using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.AuthData.Migrations.Context;
using RecipeShopper.AuthData.Migrations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.AuthData.Migrations.Registrations
{
    /// <summary>
    /// Db context registration during startup
    /// </summary>
    public static class AuthDataDbContextRegistrations
    {
        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterAuthDataDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQL_DOCKER_2019");
            services.AddDbContext<RecipeShopperAuthDataDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
