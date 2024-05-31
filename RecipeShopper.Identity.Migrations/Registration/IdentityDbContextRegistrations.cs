using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.Identity.Migrations.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Identity.Migrations.Registrations
{
    /// <summary>
    /// Db context registration during startup
    /// </summary>
    public static class IdentityDbContextRegistrations
    {
        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQL_DOCKER_2019");
            services.AddDbContext<RecipeShopperIdentityDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
