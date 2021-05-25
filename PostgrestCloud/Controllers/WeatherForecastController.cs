using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgrestCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgrestCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly MyWebApiContext _context;
        public WeatherForecastController(MyWebApiContext context)
        {
            _context = context;
        }

        // GET: api/authors
        public IEnumerable<Group> Get()
        {
            return _context.Groups.ToList();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public Group Get(int id)
        {
            return _context.Groups.FirstOrDefault(x => x.Id == id);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Group value)
        {
            _context.Groups.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}
