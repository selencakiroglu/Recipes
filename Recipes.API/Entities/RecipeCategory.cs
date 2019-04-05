using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Entities
{
    public class RecipeCategory
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
