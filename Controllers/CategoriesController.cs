using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyOwnApi.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<Categories> Get()
        //{
        //    var rng = new Random();
        //    var categories = new Categories();
        //    return Enumerable.Range(1, 5).Select(index => new Categories
        //    {
        //        Name = categories.GetCategoryById(1),
        //        Id = categories.GetIdByCategory("Laptops")
        //    })
        //    .ToArray();
        //}
        [HttpGet]
        public Categories Get()
        {
            var categories = new Categories();
            return new Categories
            {
                Name = categories.GetCategoryById(1),
                Id = categories.GetIdByCategory("Laptops")
            };
        }

        [HttpPost("Post")]
        public IEnumerable<List<string>> Post([FromHeader] string parol)
        {
            var categories = new Categories();
            var result = categories.GetCategoriesPost(parol);

            return Enumerable.Range(1, 2).Select(index => result);
        }

        //[HttpPut("Put")]
        //public void Put([FromBody] Categories value)
        //{
        //    value.PutById(value);
        //}
    }
}
