using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL.Controllers
{

    [RoutePrefix("api/pais")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaisController : ApiController
    {

        [Route("getall")]
        [HttpGet]

        public IHttpActionResult GetAll()
        {
            ML.Pais resultado = BL.Pais.GetAll();

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
