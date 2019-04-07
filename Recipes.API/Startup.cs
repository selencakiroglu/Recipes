using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipes.API.Entities;
using Recipes.API.Helpers;
using Recipes.API.Services;

namespace Recipes.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=RecipesDB;Trusted_Connection=True;";
            services.AddDbContext<RecipeContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IRecipeRepository, RecipeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            RecipeContext recipeContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Internal error occurred.");
                    });
                });
            }

            recipeContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IEnumerable<Entities.Category>, Models.CategoryListDto>()
                    .ConvertUsing<CategoryListConverter>();
                cfg.CreateMap<IEnumerable<Entities.Recipe>, Models.RecipeListDto>()
                    .ConvertUsing<RecipeListConverter>();
                cfg.CreateMap<Entities.Recipe, Models.RecipeDto>()
                    .ForMember(destination => destination.Categories, source => source.MapFrom(recipe => recipe.RecipeCategories));
                cfg.CreateMap<Entities.RecipeCategory, String>()
                 .ConvertUsing(source => source.Category.Name);
                cfg.CreateMap<Entities.Ingredient, Models.IngredientDto>();
                cfg.CreateMap<Entities.Amount, Models.AmountDto>();
                cfg.CreateMap<Entities.Directions, Models.DirectionsDto>();
            });

            app.UseMvc();
        }
    }
}
