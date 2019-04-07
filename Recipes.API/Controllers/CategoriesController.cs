using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.Models;
using Recipes.API.Services;
using System;
using System.Collections.Generic;

namespace Recipes.API.Controllers
{
    [Route("/services/recipe")]
    public class CategoriesController : ControllerBase
    {
        private IRecipeRepository _recipeRepository;

        public CategoriesController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("filter/categories")]
        public IActionResult GetCategories()
        {
            var categoryEntities = _recipeRepository.GetCategories();
            var results = Mapper.Map<CategoryListDto>(categoryEntities);

            if (results.Categories.Count == 0)
            {
                return StatusCode(204, "No categories found.");
            }

            return Ok(results);
        }
    }
}
