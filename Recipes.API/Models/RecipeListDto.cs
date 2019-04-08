using System.Collections.Generic;

namespace Recipes.API.Models
{
    public class RecipeListDto
    {
        public int Results
        {
            get
            {
                return Recipes.Count;
            }
        }

        public int Total { get; set; }

        public ICollection<RecipeDto> Recipes { get; set; }
            = new List<RecipeDto>();
    }
}
