// Nameshpace
using RecipeShopper.Api.BootStrapper;

// Web api entry point configuration
WebApplication.CreateBuilder(args)
    .RegisterDependencies() // Register dependencies
    .Build() // Build application
    .ConfigureMiddleware() // Configure middleware
    .Run(); // Run application

