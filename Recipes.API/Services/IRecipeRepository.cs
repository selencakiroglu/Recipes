using Recipes.API.Entities;
using Recipes.API.Helpers;
using System;
using System.Collections.Generic;

namespace Recipes.API.Services
{
    public interface IRecipeRepository
    {
        bool RecipeExist(String recipeTitle);
        (int TotalRecipeCount, IEnumerable<Recipe> recipes) GetRecipes(RecipesResourceParameters recipesResourceParameters);
        IEnumerable<Category> GetCategories();
        Category GetCategory(String categoryName);
        void AddRecipe(Recipe recipe);
        bool Save();
    }
}
