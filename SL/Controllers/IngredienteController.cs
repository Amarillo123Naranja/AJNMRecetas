using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL.Controllers
{
    [RoutePrefix("api/ingrediente")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class IngredienteController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Ingrediente ingrediente)
        {
            var response = BL.Ingrediente.Add(ingrediente);
            if ((bool)response["isCorrect"])
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(ML.Ingrediente ingrediente)
        {
            var response = BL.Ingrediente.Update(ingrediente);
            if ((bool)response["isCorrect"])
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [Route("{idIngrediente}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idIngrediente)
        {
            var response = BL.Ingrediente.Delete(idIngrediente);
            if ((bool)response["isCorrect"])
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [Route("{nombre}")]
        [HttpGet]
        public IHttpActionResult GetAll(string nombre)
        {
            nombre = nombre == null ? nombre = "" : nombre;
            var response = BL.Ingrediente.GetAll(nombre);
            if ((bool)response["isCorrect"])
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
        [Route("{idIngrediente}")]
        [HttpGet]
        public IHttpActionResult GetById(int idIngrediente)
        {
            var response = BL.Ingrediente.GetById(idIngrediente);
            if ((bool)response["isCorrect"])
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, response);
            }
        }
    }
}
