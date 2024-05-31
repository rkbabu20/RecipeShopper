using Microsoft.EntityFrameworkCore;
using RecipeShopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.DBContexts.DatabaseContext
{
    /// <summary>
    /// Recipe shopper data base context 
    /// </summary>
    public class RecipeShopperDbContext : DbContext
    {
        /// <summary>
        /// Recipe shopper db context
        /// </summary>
        /// <param name="options"></param>
        public RecipeShopperDbContext(DbContextOptions<RecipeShopperDbContext> options) : base(options) { }


        #region Properties
        /// <summary>User table</summary>
        public virtual DbSet<User> User { get; set; }
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
