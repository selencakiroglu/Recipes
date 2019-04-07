﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipes.API.Entities;

namespace Recipes.API.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Recipes.API.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Recipes.API.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("RecipeId");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Recipes.API.Entities.Recipe", b =>
                {
                    b.Property<Guid>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Recipes.API.Entities.RecipeCategory", b =>
                {
                    b.Property<Guid>("RecipeId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("RecipeId", "CategoryId");

                    b.HasAlternateKey("CategoryId", "RecipeId");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("Recipes.API.Entities.Ingredient", b =>
                {
                    b.HasOne("Recipes.API.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Recipes.API.Entities.Amount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("IngredientId");

                            b1.Property<string>("Quantity");

                            b1.Property<string>("Unit");

                            b1.HasKey("IngredientId");

                            b1.ToTable("Ingredients");

                            b1.HasOne("Recipes.API.Entities.Ingredient")
                                .WithOne("Amount")
                                .HasForeignKey("Recipes.API.Entities.Amount", "IngredientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Recipes.API.Entities.Recipe", b =>
                {
                    b.OwnsOne("Recipes.API.Entities.Directions", "Directions", b1 =>
                        {
                            b1.Property<Guid>("RecipeId");

                            b1.Property<string>("Step")
                                .HasMaxLength(1000);

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.HasOne("Recipes.API.Entities.Recipe")
                                .WithOne("Directions")
                                .HasForeignKey("Recipes.API.Entities.Directions", "RecipeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Recipes.API.Entities.RecipeCategory", b =>
                {
                    b.HasOne("Recipes.API.Entities.Category", "Category")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Recipes.API.Entities.Recipe", "Recipe")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}