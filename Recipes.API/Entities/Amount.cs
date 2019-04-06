using Microsoft.EntityFrameworkCore;

namespace Recipes.API.Entities
{
    [Owned]
    public class Amount
    {
        public string Quantity { get; set; }
        public string Unit { get; set; }
    }
}
