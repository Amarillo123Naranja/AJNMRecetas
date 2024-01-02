using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/restaurantereceta")]
    public class RestauranteRecetaController : ApiController
    {
        [Route("getbyid/{idRestaurante}")]
        [HttpGet]

        public IHttpActionResult GetById(int idRestaurante)
        {
            
            ML.RestauranteReceta resultado = BL.RestauranteReceta.GetbyId(idRestaurante);

            if (resultado.Correct)
            {
                return Content(HttpStatusCode.OK, resultado);
            }
            else 
            {
                return Content(HttpStatusCode.BadGateway, resultado);   

            }


        }


    }
}
