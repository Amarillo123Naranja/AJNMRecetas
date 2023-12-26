using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{

    [RoutePrefix("pais")]  
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
