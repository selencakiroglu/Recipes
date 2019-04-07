using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.API.Entities
{
    public class Ingredient
    {
        [Key]
        public Guid IngredientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public Amount Amount { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        public Guid RecipeId { get; set; }
    }
}
