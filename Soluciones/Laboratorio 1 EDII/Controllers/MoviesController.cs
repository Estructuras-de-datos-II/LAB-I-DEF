using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
        //// GET: api/<MoviesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        //// GET api/<MoviesController>/5
        //[HttpGet("{titulo}")]
        //public ActionResult getByString([FromRoute] string Titulo)
        //{
        //    var result = Singleton.Instance.Movie.Where(x => x.titulo == Titulo).FirstOrDefault<Movies>();
        //    if (result == null) return NotFound();
        //    return Ok(result);
        
        //}
        //DELETE api/<MoviesController>
        //[HttpDelete]
        //public ActionResult Delete()
        //{
        //    Singleton.Instance.arbolB.eliminar;

        //    return NoContent();
        //}




        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult Post([FromBody] Order newValue)
        {
            try
            {
                if (Convert.ToInt32(newValue.Orders) % 2 != 0)
                {
                    Singleton.Instance.Orders = Convert.ToInt32(newValue.Orders);
                   return Created("", newValue);
                }

                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest("NUMERO DEBERÍA DE SER IMPAR");
            }
        }

        //// DELETE api/<MoviesController>/5
        //[HttpDelete("{titulo}")]
        //public ActionResult Delete(string Titulo)
        //{
        //    var result = Singleton.Instance.Movie.Where(x => x.titulo == Titulo).FirstOrDefault<Movies>();
        //    if (result == null) return NotFound();
        //    Singleton.Instance.Movie.RemoveAll(x => x.titulo == Titulo);
        //    return NoContent();
        //}




        // POST api/<MoviesController/populate>

        [HttpPost("populate")]
        public async Task<ActionResult> Create([FromForm] ICollection<IFormFile> file)
        {
            try
            {
                foreach (Movies item in file)
                {
                    item.id = Singleton.Instance.LastId + 1;
                    Singleton.Instance.LastId++;
                    Singleton.Instance.arbolB.insertar(item);
                }
                return Created("", file);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST api/<MoviesController/import>
        [HttpPost("import")]
        public ActionResult Post([FromBody] List<Movies> newListValue)
        {

            try
            {
                foreach (Movies item in newListValue)
                {
                    item.id = Singleton.Instance.LastId + 1;
                    Singleton.Instance.LastId++;
                    Singleton.Instance.arbolB.insertar(item);

                }
                return Created("", newListValue);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
