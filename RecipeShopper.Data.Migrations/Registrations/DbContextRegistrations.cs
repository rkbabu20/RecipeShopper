using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Migrations.Registrations
{
    /// <summary>
    /// Db context registration during startup
    /// </summary>
    public static class DbContextRegistrations
    {
        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MS_SQL_2019");
            services.AddDbContext<RecipeShopperDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
