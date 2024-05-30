﻿using Microsoft.Extensions.DependencyInjection;
using RecipeShopper.Contracts;
using RecipeShopper.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.Data.Registrations
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
                serviceCollection.AddScoped<IRepositories, Repositories.Repositories>();
                serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
                serviceCollection.AddScoped<ICartRepository, CartRepository>();
                serviceCollection.AddScoped<ILoginRepository, LoginRepository>();
                serviceCollection.AddScoped<IOrdersRepository, OrdersRepository>();
                serviceCollection.AddScoped<IIngradientsRepository, IngradientsRepository>();
            }
        }
    }
}
