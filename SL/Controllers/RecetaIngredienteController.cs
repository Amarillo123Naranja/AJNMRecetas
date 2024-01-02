using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL.Controllers
{
    [RoutePrefix("api/recetaingrediente")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RecetaIngredienteController : ApiController
    {
        [Route("getbyid/{idReceta}")]
        [HttpGet]
        public IHttpActionResult GetById(int idReceta)
        {
            
            ML.RecetaIngrediente resultado = BL.RecetaIngrediente.GetbyId(idReceta);

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
