using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Entities
{
    [Owned]
    public class Ingredient
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public Amount Amount { get; set; }
    }
}
