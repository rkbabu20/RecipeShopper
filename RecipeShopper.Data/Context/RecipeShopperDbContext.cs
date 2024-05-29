using Microsoft.EntityFrameworkCore;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.Data.Context
{
    public class RecipeShopperDbContext : DbContext
    {
        public RecipeShopperDbContext(DbContextOptions<RecipeShopperDbContext> options) : base(options) 
        { 
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
