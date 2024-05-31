using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using RecipeShopper.Domain.Entities;
using RecipeShopper.Domain.Enums;

namespace RecipeShopper.Data.Context
{
    /// <summary>
    /// Recipe shopper db context
    /// </summary>
    public class RecipeShopperDbContext : DbContext
    {
        #region Constructor
        public RecipeShopperDbContext(DbContextOptions<RecipeShopperDbContext> options) : base(options) { }
        #endregion

        #region Properties
        /// <summary>User table</summary>
        //public virtual DbSet<User> User { get; set; }
        /// <summary>Cart table</summary>
        public virtual DbSet<Cart> Cart { get; set; }
        /// <summary>Ingradient table</summary>
        public virtual DbSet<Ingradient> Ingradient { get; set; }
        /// <summary>Recipe table</summary>
        public virtual DbSet<Recipe> Recipe { get; set; }
        /// <summary>Login table</summary>
        public virtual DbSet<Login> Login { get; set; }
        /// <summary>Order table</summary>
        public virtual DbSet<Order> Order { get; set; }
        #endregion

    }// End RecipeShopperDbContext
}
