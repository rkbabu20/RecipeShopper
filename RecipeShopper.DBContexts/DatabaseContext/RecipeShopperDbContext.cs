using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeShopper.Domain.Entities;
using RecipeShopper.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.DBContexts.DatabaseContext
{
    /// <summary>
    /// Recipe shopper database context 
    /// </summary>
    public class RecipeShopperDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Recipe shopper db context
        /// </summary>
        /// <param name="options"></param>
        public RecipeShopperDbContext(DbContextOptions<RecipeShopperDbContext> options) : base(options) { }

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
        /// <summary>Cart table</summary>
        public virtual DbSet<Cart> Cart { get; set; }
        /// <summary>Ingradient table</summary>
        public virtual DbSet<CartIngradient> CartIngradients { get; set; }
        /// <summary>Stock table</summary>
        public virtual DbSet<StockIngradient> StockIngradients { get; set; }
        /// <summary>Recipe table</summary>
        public virtual DbSet<Recipe> Recipes { get; set; }
        /// <summary>Order table</summary>
        public virtual DbSet<Order> Orders { get; set; }
        #endregion

    }// End RecipeShopperDbContext
}
