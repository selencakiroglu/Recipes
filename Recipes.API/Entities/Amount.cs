using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Entities
{
    [Owned]
    public class Amount
    {
        public string Quantity { get; set; }
        public string Unit { get; set; }
    }
}
