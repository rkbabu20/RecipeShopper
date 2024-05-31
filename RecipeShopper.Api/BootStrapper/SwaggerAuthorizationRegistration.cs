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
                services.AddSwaggerGen(options =>
                {
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
