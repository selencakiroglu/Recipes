using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.Entities;
using Recipes.API.Helpers;
using Recipes.API.Models;
using Recipes.API.Services;
using System;
using System.Linq;

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

        [HttpPost("all", Name = "GetRecipes")]
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

        [HttpPut("add")]
        public IActionResult CreateRecipe([FromBody] RecipeForCreationDto recipeDto)
        {
            if (recipeDto == null)
            {
                return StatusCode(400, "Wrong JSON object.");
            }

            if (recipeDto.Categories.Count() < 1)
            {
                ModelState.AddModelError(nameof(RecipeForCreationDto),
                    "You should fill out at least one category.");
            }

            if (recipeDto.Ingredients.Count() < 1)
            {
                ModelState.AddModelError(nameof(RecipeForCreationDto),
                    "You should fill out at least one ingredient.");
            }

            if (String.IsNullOrEmpty(recipeDto.Directions.Step))
            {
                ModelState.AddModelError(nameof(RecipeForCreationDto),
                    "You should fill out direction step.");
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            if (_recipeRepository.RecipeExist(recipeDto.Title))
            {
                return StatusCode(409, "Recipe duplicated.");
            }
            
            var recipeEntity = Mapper.Map<Recipe>(recipeDto);

            foreach (var categoryName in recipeDto.Categories)
            {
                var recipeCategory = new RecipeCategory();
                var category = _recipeRepository.GetCategory(categoryName);

                if (category == null)
                {
                    recipeCategory.Category = new Category()
                    {
                        CategoryId = Guid.NewGuid(),
                        Name = categoryName
                    };
                }
                else
                {
                    recipeCategory.Category = category;
                }
                recipeEntity.RecipeCategories.Add(recipeCategory);
            }

            _recipeRepository.AddRecipe(recipeEntity);

            if (!_recipeRepository.Save())
            {
                return StatusCode(500, "Internal error occured.");
            }

            var recipeToReturn = Mapper.Map<RecipeDto>(recipeEntity);

            return CreatedAtRoute("GetRecipes", null, recipeToReturn);
        }
    }
}
