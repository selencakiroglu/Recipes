using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Helpers
{
    public class RecipesResourceParameters
    {
        public string SearchQuery { get; set; }
        public string Category { get; set; }
        public string Ingredient { get; set; }
    }
}
