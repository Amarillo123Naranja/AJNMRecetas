using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/recetaingrediente")]  
    public class RecetaIngredienteController : ApiController
    {
        [Route("getall/{idReceta}")]
        [HttpGet]
        public IHttpActionResult GetAll(int? idReceta)
        {
            if(idReceta == 0)
            {
                idReceta = 0;
            }

            ML.RecetaIngrediente resultado = BL.RecetaIngrediente.GetAll(idReceta.Value);

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
