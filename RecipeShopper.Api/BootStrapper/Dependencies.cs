﻿using RecipeShopper.DBContexts.Registrations;
using RecipeShopper.Application.Services.Registrations;
using RecipeShopper.Data.Repositories.Registrations;
using System.Text.Json.Serialization;

namespace RecipeShopper.Api.BootStrapper
{
    /// <summary>
    /// Dependencies registrations
    /// </summary>
    public static class Dependencies
    {
        /// <summary>
        /// Register dependencies
        /// </summary>
        /// <param name="builder">WebApplicationBuilder</param>
        /// <returns>WebApplicationBuilder</returns>
        public static WebApplicationBuilder RegisterDependencies(this WebApplicationBuilder builder)
        {
            if (builder != null)
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                // AutoMapper registration
                builder.Services.AddAutoMapper(assemblies);
                // MediateR registration - For CQRS
                builder.Services.RegisterMediatR();
                builder.Services.RegisterDbContext(builder.Configuration);
                builder.Services.RegisterRepositories();
               // builder.Services.RegisterIAMDbContext(builder.Configuration);
                // Add services to the container.
                builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddAuthorizationToSwagger();
                builder.Services.AddCustomAuthorization();
            }
            return builder!;
        }
    }
}
