﻿using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<User> Users { get; set; }
        /// <summary>Cart table</summary>
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

    }// End RecipeShopperDbContext
}
