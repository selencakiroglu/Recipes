using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Models
{
    public class RecipeDto
    {
        public string Title { get; set; }
        public IEnumerable<String> Categories { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
            = new List<IngredientDto>();
        public DirectionsDto Directions { get; set; }
    }
}
