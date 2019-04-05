﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Entities
{
    public class Recipe
    {
        [Key]
        public Guid RecipeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public ICollection<RecipeCategory> RecipeCategories  { get; set; }
            = new List<RecipeCategory>();

        [Required]
        public ICollection<Ingredient> Ingredients { get; set; }
            = new List<Ingredient>();

        [Required]
        [MaxLength(1000)]
        public string Directions { get; set; }
    }
}