﻿using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.Application.Contracts;
using RecipeShopper.Application.Contracts.Configurations;
using RecipeShopper.Data.Repositories;
using RecipeShopper.Data.Repositories.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Repositories.Registrations
{
    /// <summary>
    /// Repositories registration
    /// </summary>
    public static class RepositoriesRegistration
    {
        /// <summary>
        /// Register repositories
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
            if (serviceCollection != null)
            {
                serviceCollection.AddScoped<IRepositories, Repositories>();
                serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
                serviceCollection.AddScoped<ICartRepository, CartRepository>();
                serviceCollection.AddScoped<IOrdersRepository, OrdersRepository>();
                serviceCollection.AddScoped<IStockIngradientsRepository, StockIngradientsRepository>();
                serviceCollection.AddScoped<ILoginRepository, LoginRepository>();
            }
        }

        /// <summary>
        /// Register repositories
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void RegisterRepositoriesConfiguration(this IServiceCollection serviceCollection)
        {
            if (serviceCollection != null)
            {
                serviceCollection.AddScoped<IJWTTokenConfiguration, JWTTokenConfiguration>();
            }
        }
    }
}
