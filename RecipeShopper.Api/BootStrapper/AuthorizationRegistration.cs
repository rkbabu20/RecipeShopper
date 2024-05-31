using RecipeShopper.AuthData.Migrations.Context;
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
                service.AddIdentityApiEndpoints<User>()
                    .AddEntityFrameworkStores<RecipeShopperAuthDataDbContext>();
            }
        }
    }
}
