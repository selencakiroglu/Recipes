using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Models
{
    public class CategoryListDto
    {
        public int Results
        {
            get
            {
                return Categories.Count;
            }
        }

        public ICollection<String> Categories { get; set; }
        = new List<String>();
    }
}
