using Microsoft.AspNetCore.Mvc;
using Recipes.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.API.Controllers
{
    public class DummyController : ControllerBase
    {
        private RecipesContext _ctx;

        public DummyController(RecipesContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
