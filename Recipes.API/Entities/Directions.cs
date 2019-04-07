using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Recipes.API.Entities
{
    [Owned]
    public class Directions
    {
        [MaxLength(1000)]
        public string Step { get; set; }
    }
}
