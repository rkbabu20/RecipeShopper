using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeShopper.DBContexts.IdentityContext;
using RecipeShopper.Domain.Entities;

namespace RecipeShopper.DBContexts.AuthDbContext
{
    /// <summary>
    /// Recipe shopper IAM DbContext
    /// </summary>
    /// <remarks>
    /// RecipeShopperIAMDbContext
    /// </remarks>
    /// <param name="options">Db context options</param>
    public class ApplicationAuthDbContext : IdentityDbContext<User>
    {

        /// <summary>
        /// RecipeShopperIAMDbContext
        /// </summary>
        /// <param name="options">Db context options</param>
        public ApplicationAuthDbContext(DbContextOptions<RecipeShopperIAMDbContext> options) : base(options) { }

        /// <summary>
        /// On model creating 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity => { entity.ToTable(name: "AspNetUsers"); });
        }

        #region Properties
        public virtual DbSet<Cart> Cart { get; set; }
        /// <summary>Ingradient table</summary>
        public virtual DbSet<CartIngradient> CartIngradients { get; set; }
        /// <summary>Stock table</summary>
        public virtual DbSet<StockIngradient> StockIngradients { get; set; }
        /// <summary>Recipe table</summary>
        public virtual DbSet<Recipe> Recipes { get; set; }
        /// <summary>Login table</summary>
        public virtual DbSet<Login> Login { get; set; }
        /// <summary>Order table</summary>
        public virtual DbSet<Order> Orders { get; set; }
        #endregion

    }// End RecipeShopperIAMDbContext
}
