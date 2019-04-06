using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recipes.API.Entities
{
    [Owned]
    public class Ingredient
    {
        [Key]
        public Guid IngredientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public Amount Amount { get; set; }
    }
}
