using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio_1_EDII.Models;
using Laboratorio_1_EDII.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Laboratorio_1_EDII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MoviesController>/5
        [HttpGet("{titulo}")]
        public ActionResult getByString([FromRoute] string Titulo)
        {
            var result = Singleton.Instance.Movie.Where(x => x.titulo == Titulo).FirstOrDefault<Movies>();
            if (result == null) return NotFound();
            return Ok(result);
        
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult Post([FromBody] Movies newValue)
        {
            try
            {
                var result = Singleton.Instance.Movie.Where(x => x.titulo == newValue.titulo).FirstOrDefault<Movies>();
                if (result != null) return BadRequest();

                newValue.id = Singleton.Instance.LastId + 1;
                Singleton.Instance.Movie.Add(newValue);
                Singleton.Instance.LastId++;
                return Created("", newValue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
