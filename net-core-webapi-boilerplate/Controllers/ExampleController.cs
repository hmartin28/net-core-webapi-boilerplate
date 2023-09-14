using Microsoft.AspNetCore.Mvc;
using net_core_webapi_boilerplate.Data;
using net_core_webapi_boilerplate.Models;

namespace net_core_webapi_boilerplate.Controllers
{
    [Route("api")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly ApplicationDatabaseContext _context;

        public ExampleController(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var results = _context.Examples.ToList();

            if (results.Count > 0)
            {
                return Ok(results);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }    
        }

        [HttpGet("get/id")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            else
            {
                var result = _context.Examples
                    .Where(i => i.ID == id)
                    .FirstOrDefault();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
        }

        [HttpPost("post")]
        public IActionResult Post(Example example)
        {
            if (example.Name == "" || example.Email == "" || example.Password == "")
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            else
            {
                Example newEntry = new Example()
                {
                    Name = example.Name,
                    Email = example.Email,
                    Password = example.Password
                };

                if (newEntry != null)
                {
                    _context.Examples.Add(newEntry);
                    _context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpPut("edit")]
        public IActionResult Edit(Example example)
        {
            if (example.ID == 0 || example.Name == "" || example.Email == "" || example.Password == "")
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            else
            {
                if (example != null)
                {
                    _context.Update(example);
                    _context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var recordToDelete = _context.Examples
                    .Where(i => i.ID == id)
                    .FirstOrDefault();

                if (recordToDelete != null)
                {
                    _context.Examples.Remove(recordToDelete);
                    _context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
        }
    }
}
