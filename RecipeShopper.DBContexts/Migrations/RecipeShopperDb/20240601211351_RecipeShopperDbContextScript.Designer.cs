﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeShopper.DBContexts.DatabaseContext;

#nullable disable

namespace RecipeShopper.DBContexts.Migrations.RecipeShopperDb
{
    [DbContext(typeof(RecipeShopperDbContext))]
    [Migration("20240601211351_RecipeShopperDbContextScript")]
    partial class RecipeShopperDbContextScript
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOrderComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.CartIngradient", b =>
                {
                    b.Property<Guid>("CartIngradientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityType")
                        .HasColumnType("int");

                    b.Property<Guid?>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StockIngradientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartIngradientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("CartIngradients");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Login", b =>
                {
                    b.Property<Guid>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginId");

                    b.HasIndex("UserId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecipeId");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.StockIngradient", b =>
                {
                    b.Property<Guid>("StockIngradientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityType")
                        .HasColumnType("int");

                    b.HasKey("StockIngradientId");

                    b.ToTable("StockIngradients");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Cart", b =>
                {
                    b.HasOne("RecipeShopper.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.CartIngradient", b =>
                {
                    b.HasOne("RecipeShopper.Domain.Entities.Recipe", null)
                        .WithMany("Ingradients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Login", b =>
                {
                    b.HasOne("RecipeShopper.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Order", b =>
                {
                    b.HasOne("RecipeShopper.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeShopper.Domain.Entities.Cart", null)
                        .WithMany("Recipes")
                        .HasForeignKey("CartId");

                    b.HasOne("RecipeShopper.Domain.Entities.Order", null)
                        .WithMany("Recipes")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Order", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeShopper.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Ingradients");
                });
#pragma warning restore 612, 618
        }
    }
}
