using System;
using System.Collections.Generic;

namespace Recipes.API.Entities
{
    public static class RecipeContextExtensions
    {
        public static void EnsureSeedDataForContext(this RecipeContext context)
        {
            context.Categories.RemoveRange(context.Categories);
            context.Recipes.RemoveRange(context.Recipes);
            context.SaveChanges();

            var recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    RecipeId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Title = "30 Minute Chili",
                    RecipeCategories = new List<RecipeCategory>()
                    {
                        new RecipeCategory()
                        {
                            Category = new Category()
                            {
                                CategoryId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                                Name = "Main dish"
                            }
                        },
                        new RecipeCategory()
                        {
                            Category = new Category()
                            {
                                CategoryId = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                                Name = "Chili"
                            }
                        }
                    },
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = "pound"
                            },
                            Name = "Ground chuck or lean ground; beef"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = ""
                            },
                            Name = "Onion; large, chopped"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = "can"
                            },
                            Name = "Kidney beans; (12 oz)"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = "can"
                            },
                            Name = "Tomato soup; undiluted"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = "teaspoon"
                            },
                            Name = "Salt"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "1",
                                Unit = "tablespoon"
                            },
                            Name = "Chili powder; (or to taste)"
                        },
                        new Ingredient()
                        {
                            IngredientId = new Guid(),
                            Amount = new Amount()
                            {
                                Quantity = "",
                                Unit = ""
                            },
                            Name = "Hot pepper sauce; to taste"
                        }
                    },
                    Directions = new Directions()
                    {
                        Step = "  Brown the meat in a little butter and cook until the meat is brown -- about\n  10 minutes. Add all other ingredients and let simmer for 30 minutes. Your\n  choice of hot sauce may be added to taste.\n  \n  Recipe by: MasterCook Archives\n  \n  Posted to recipelu-digest Volume 01 Number 577 by Rodeo46898\n  <Rodeo46898@aol.com> on Jan 22, 1998\n \n"
                    }
                }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
