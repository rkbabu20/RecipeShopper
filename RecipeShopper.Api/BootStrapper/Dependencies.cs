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
                // Add services to the container.
                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }
            return builder!;
        }
    }
}
