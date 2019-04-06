using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.API.Entities
{
    public class RecipeCategory
    {
        [Key, Column(Order = 0)]
        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        [Key, Column(Order = 1)]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
