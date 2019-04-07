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
        private RecipeContext _ctx;

        public DummyController(RecipeContext ctx)
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
