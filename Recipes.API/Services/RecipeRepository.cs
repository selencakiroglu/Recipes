using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipes.API.Entities;
using Recipes.API.Helpers;

namespace Recipes.API.Services
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeContext _context;

        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(category => category.Name).ToList();
        }

        public (int TotalRecipeCount, IEnumerable<Recipe> recipes) GetRecipes(RecipesResourceParameters recipesResourceParameters)
        {
            var recipes = _context.Recipes
                .Include(recipe => recipe.Ingredients)
                .Include(recipe => recipe.RecipeCategories)
                    .ThenInclude(recipeCategory => recipeCategory.Category)
                .OrderBy(recipe => recipe.Title).ToList();

            var totalRecipeCount = recipes.Count;

            if (!string.IsNullOrEmpty(recipesResourceParameters.Category))
            {
                var categoryForWhereClause = recipesResourceParameters.Category
                    .Trim().ToLowerInvariant();
                recipes = recipes
                    .Where(recipe => recipe.RecipeCategories.Any(rc => rc.Category.Name.Trim().ToLowerInvariant() == categoryForWhereClause)).ToList();
            }

            if (!string.IsNullOrEmpty(recipesResourceParameters.Ingredient))
            {
                var ingredientForWhereClause = recipesResourceParameters.Ingredient
                    .Trim().ToLowerInvariant();
                recipes = recipes
                    .Where(recipe => recipe.Ingredients.Any(ingredient => ingredient.Name.Trim().ToLowerInvariant().Contains(ingredientForWhereClause))).ToList();
            }

            if (!string.IsNullOrEmpty(recipesResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = recipesResourceParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                recipes = recipes
                    .Where(recipe => recipe.RecipeCategories.Any(rc => rc.Category.Name.Trim().ToLowerInvariant().Contains(searchQueryForWhereClause))
                    || recipe.Ingredients.Any(ingredient => ingredient.Name.Trim().ToLowerInvariant().Contains(searchQueryForWhereClause))
                    || recipe.Title.Trim().ToLowerInvariant().Contains(searchQueryForWhereClause)).ToList();
            }

            return (totalRecipeCount, recipes);
        }

        public bool RecipeExist(Guid recipeId)
        {
            return _context.Recipes.Any(r => r.RecipeId == recipeId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
