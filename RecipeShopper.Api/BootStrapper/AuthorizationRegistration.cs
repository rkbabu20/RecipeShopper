using Microsoft.AspNetCore.Identity;
using RecipeShopper.DBContexts.IdentityContext;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Api.BootStrapper
{
    public static class AuthorizationRegistration
    {
        public static void AddCustomAuthorization(this IServiceCollection service)
        {
            if(service!=null)
            {
                service.AddAuthorization();
                service.AddIdentityApiEndpoints<IdentityUser>()
                    .AddEntityFrameworkStores<RecipeShopperIAMDbContext>();
            }
        }
    }
}
