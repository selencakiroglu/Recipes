using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recipes.API.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ICollection<RecipeCategory> RecipeCategories { get; set; }
            = new List<RecipeCategory>();
    }
}
