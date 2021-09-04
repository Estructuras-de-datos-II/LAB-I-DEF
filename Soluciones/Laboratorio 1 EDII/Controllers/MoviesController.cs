using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Laboratorio_1_EDII.Models;
using Laboratorio_1_EDII.Data;
using System.Text;
using System;
using Newtonsoft.Json;


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
        public  IActionResult PostFile([FromForm] IFormFile file)
        {
            using var archivojason = new MemoryStream();
            try
            {
                file.CopyToAsync(archivojason);
                var pelicula = Encoding.ASCII.GetString(archivojason.ToArray());
                var movieslist = JsonConvert.DeserializeObject<List<Movies>>(pelicula);
                foreach (Movies item in movieslist)
                {
                    item.id = Singleton.Instance.LastId + 1;
                    Singleton.Instance.LastId++;
                    Singleton.Instance.arbolB.insertar(item);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        //// POST api/<MoviesController/populate/id>

        //[HttpPost("populate/{id}")]
        //public IActionResult Delete([FromRoute] string id)
        //{

        //    try
        //    {
        //        Movies eliminarid = new Movies();
        //        eliminarid.id = Convert.ToInt32(id);

        //        if(Singleton.Instance.arbolB.eliminar(eliminarid))
        //        {
        //            return Ok();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }

        //}

        // POST api/<MoviesController/populate/id>
        [HttpDelete("populate/{id}")]
        public ActionResult Delete(string id)
        {
            try { 
            Movies eliminarid = new Movies();
            eliminarid.id = Convert.ToInt32(id);
            Singleton.Instance.arbolB.eliminar(eliminarid);
            return Ok();
            }
            catch(Exception ex)
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


        // PARA BORRAR EN EL IMPORT

        ////POST api/<MoviesController/import/id>
        ////[HttpDelete("import/{id}")]
        ////public ActionResult Delete(string id)
        ////{
        ////    Movies eliminarid = new Movies();
        ////    eliminarid.id = Convert.ToInt32(id);
        ////    Singleton.Instance.arbolB.eliminar(eliminarid);
        ////    return Ok();
        ////}
    }
}
