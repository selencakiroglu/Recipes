using AutoMapper;
using Recipes.API.Entities;
using Recipes.API.Models;
using System.Collections.Generic;

namespace Recipes.API.Helpers
{
    public class CategoryListConverter : ITypeConverter<IEnumerable<Category>, CategoryListDto>
    {
        public CategoryListDto Convert(IEnumerable<Category> source, CategoryListDto destination, ResolutionContext context)
        {
            var categoryListDto = new CategoryListDto();
            
            foreach(var category in source)
            {
                categoryListDto.Categories.Add(category.Name);
            }

            return categoryListDto;
        }
    }
}
