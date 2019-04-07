using Recipes.API.Entities;
using Recipes.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Services
{
    public interface IRecipeRepository
    {
        bool RecipeExist(Guid recipeId);
        (int TotalRecipeCount, IEnumerable<Recipe> recipes) GetRecipes(RecipesResourceParameters recipesResourceParameters);
        IEnumerable<Category> GetCategories();
        bool Save();
    }
}
