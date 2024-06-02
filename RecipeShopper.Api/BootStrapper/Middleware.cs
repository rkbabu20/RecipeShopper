﻿using Microsoft.AspNetCore.Identity;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.BootStrapper
{
    /// <summary>
    /// Middleware configurations
    /// </summary>
    public static class Middleware
    {
        /// <summary>
        /// Configure middle ware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Identity api mapping
            app.MapIdentityApi<User>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;

        }
    }
}
