using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL.Controllers
{
    [RoutePrefix("api/receta")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RecetaController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll(string nombre, string pais)
        {
            if(nombre == null)
            {
                nombre = "";
            }
            if(pais == null)
            {
                pais = "";
            }
            ML.Receta result = BL.Receta.GetAll(nombre, pais);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("{IdReceta}")]
        public IHttpActionResult GetById(int IdReceta)
        {
            ML.Receta result= BL.Receta.GetById(IdReceta);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(ML.Receta receta)
        {
            ML.Receta result=BL.Receta.Add(receta);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        [Route("{IdReceta}")]
        public IHttpActionResult Update(int IdReceta, [FromBody]ML.Receta receta)
        {
            ML.Receta result=BL.Receta.Update(receta);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("{IdReceta}")]
        public IHttpActionResult Delete(int IdReceta)
        {
            ML.Receta result=BL.Receta.Delete(IdReceta);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        
    }
}
