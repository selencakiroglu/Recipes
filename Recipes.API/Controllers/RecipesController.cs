using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.Helpers;
using Recipes.API.Models;
using Recipes.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Controllers
{
    [Route("services/recipe")]
    public class RecipesController : ControllerBase
    {
        private IRecipeRepository _recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpPost("all")]
        public IActionResult GetRecipes(
            [FromBody] RecipesResourceParameters recipesResourceParameters)
        {
            var getRecipesResult = _recipeRepository.GetRecipes(recipesResourceParameters);
            var results = Mapper.Map<RecipeListDto>(getRecipesResult.recipes);

            results.Total = getRecipesResult.TotalRecipeCount;

            if (results.Recipes.Count == 0)
            {
                return StatusCode(204, "No categories found.");
            }

            return Ok(results);
        }
    }
}
