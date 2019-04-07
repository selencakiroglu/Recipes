using AutoMapper;
using Recipes.API.Entities;
using Recipes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Helpers
{
    public class RecipeListConverter : ITypeConverter<IEnumerable<Recipe>, RecipeListDto>
    {
        public RecipeListDto Convert(IEnumerable<Recipe> source, RecipeListDto destination, ResolutionContext context)
        {
            var recipeDtos = Mapper.Map<IEnumerable<RecipeDto>>(source);
            var recipeListDto = new RecipeListDto();

            foreach (var recipe in recipeDtos)
            {
                recipeListDto.Recipes.Add(recipe);
            }

            return recipeListDto;
        }
    }
}
