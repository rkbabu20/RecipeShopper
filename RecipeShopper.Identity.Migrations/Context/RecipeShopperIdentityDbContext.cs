using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeShopper.Identity.Migrations.Context
{
    /// <summary>
    /// Recipe shopper identity db context
    /// </summary>
    public class RecipeShopperIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public RecipeShopperIdentityDbContext(DbContextOptions<RecipeShopperIdentityDbContext> options) : base(options) { }
    }//End RecipeShopperIdentityDbContext
}
