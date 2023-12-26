using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("categoria")]
    public class CategoriaController : ApiController
    {

        [Route("getall")]
        [HttpGet]

        public IHttpActionResult GetAll()
        {

            ML.Categoria resultado = BL.Categoria.GetAll();

            if (resultado.Correct)
            {
                return Content(HttpStatusCode.OK, resultado);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, resultado);
            }

        }



    }
}
