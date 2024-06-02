﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeShopper.DBContexts.IdentityContext
{
    /// <summary>
    /// Recipe shopper IAM DbContext
    /// </summary>
    public class RecipeShopperIAMDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// RecipeShopperIAMDbContext
        /// </summary>
        /// <param name="options">Db context options</param>
        public RecipeShopperIAMDbContext(DbContextOptions<RecipeShopperIAMDbContext> options) : base(options) { }

        /// <summary>
        /// On model creating 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "AspNetUsers"); });
        }

    }// End RecipeShopperIAMDbContext
}