using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recipes.API.Models
{
    public class RecipeForCreationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You should fill out at least one category.")]
        public IEnumerable<String> Categories { get; set; }

        [Required(ErrorMessage = "You should fill out at least one ingredient.")]
        public ICollection<IngredientDto> Ingredients { get; set; }
            = new List<IngredientDto>();

        [Required(ErrorMessage = "You should fill out directions.")]
        public DirectionsDto Directions { get; set; }
    }
}
