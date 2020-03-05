using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chill", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
            // _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetValues(){
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNames(int id){
            var values = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(values);
        }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     // throw new Exception("Test Exception");
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
