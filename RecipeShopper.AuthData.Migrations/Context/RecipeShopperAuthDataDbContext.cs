using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeShopper.AuthData.Migrations.Context
{
    /// <summary>
    /// Recipe shopper identity db context
    /// </summary>
    public class RecipeShopperAuthDataDbContext : IdentityDbContext<IdentityUser>
    {
        public RecipeShopperAuthDataDbContext(DbContextOptions<RecipeShopperAuthDataDbContext> options) : base(options) { }
    }//End RecipeShopperIdentityDbContext
}
