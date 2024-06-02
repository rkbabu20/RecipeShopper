﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.DBContexts.DatabaseContext;
using RecipeShopper.DBContexts.IdentityContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeShopper.DBContexts.AuthDbContext;

namespace RecipeShopper.DBContexts.Registrations
{
    /// <summary>
    /// Public DB Context registrations
    /// </summary>
    public static class DbContextRegistrations
    {
        #region Constants
        const string CONNECTION_STRING_KEY = "MS_SQL_SERVER_2019";
        #endregion

        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CONNECTION_STRING_KEY);
            services.AddDbContext<RecipeShopperDbContext>(options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterIAMDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CONNECTION_STRING_KEY);
            services.AddDbContext<RecipeShopperIAMDbContext>(options => options.UseSqlServer(connectionString));
        }

        /// <summary>
        /// Register db context
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Applicatoin configuration</param>
        public static void RegisterAuthDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AUTH_DB_MS_SQL_SERVER_2019");
            services.AddDbContext<ApplicationAuthDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
