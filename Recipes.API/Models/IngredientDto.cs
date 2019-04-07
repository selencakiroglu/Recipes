using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Models
{
    public class IngredientDto
    {
        public string Name { get; set; }
        public AmountDto Amount { get; set; }
    }
}
