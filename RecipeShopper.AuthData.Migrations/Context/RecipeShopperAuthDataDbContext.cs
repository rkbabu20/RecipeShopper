using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.AuthData.Migrations.Context
{
    /// <summary>
    /// Recipe shopper identity db context
    /// </summary>
    public class RecipeShopperAuthDataDbContext : IdentityDbContext<IdentityUser>
    {
        public RecipeShopperAuthDataDbContext(DbContextOptions<RecipeShopperAuthDataDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "AspNetUsers"); });
        }

    }//End RecipeShopperIdentityDbContext
}
