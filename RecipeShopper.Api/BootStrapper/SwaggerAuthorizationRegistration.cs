using Swashbuckle.AspNetCore.Filters;

namespace RecipeShopper.Api.BootStrapper
{
    /// <summary>
    /// Swagger authorization
    /// </summary>
    public static class SwaggerAuthorizationRegistration
    {
        /// <summary>
        /// Swagger authorization registration
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthorizationToSwagger(this IServiceCollection services)
        {
            if (services != null)
            {
                services.AddEndpointsApiExplorer();
                
                // Add swagger authorization to swagger 
                services.AddSwaggerGen(options =>
                {
                    // Swagger documentation
                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                    { 
                        Title = "Recipe Shopper Api", 
                        Version = "",
                        Description="<b>Recipe Shopper Api</b> is a web api for registering users, login, and build recipes to order."
                    });
                    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey

                    });
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                });
            }
        }
    }
}
