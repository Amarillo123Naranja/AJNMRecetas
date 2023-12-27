using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/Restaurante")]
    public class RestauranteController : ApiController
    {
        [Route("GetAll/{pais?}/{receta?}/{calificacion?}")]
        [HttpGet]
        public IHttpActionResult GetAll(string pais,string receta, int calificacion)
        {
            List<object> lista = BL.Restaurante.GetAll(pais, receta, calificacion);
            if(lista != null) 
            {
                return Content(HttpStatusCode.OK, lista);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, lista);
            }
        }

        [Route("GetById/{IdRestaurante?}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdRestaurante)
        {
            object lista = BL.Restaurante.GetbyId(IdRestaurante);
            if(lista != null)
            {
                return Content(HttpStatusCode.OK, lista);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, lista);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Restaurante restaurante)
        {
            bool result = BL.Restaurante.Add(restaurante);

            if(result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdRestaurante?}")]
        [HttpPut]
        public IHttpActionResult Update(int IdRestaurante, [FromBody] ML.Restaurante restaurante)
        {
            restaurante.IdRestaurante = IdRestaurante;
            bool result = BL.Restaurante.Update(restaurante);

            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdRestaurante?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdRestaurante)
        {
            bool result = BL.Restaurante.Delete(IdRestaurante);

            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
