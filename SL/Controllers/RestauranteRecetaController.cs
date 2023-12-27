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
        [Route("getall/{idRestaurante}")]
        [HttpGet]

        public IHttpActionResult GetAll(int? idRestaurante)
        {
            if (idRestaurante == 0)
            {
                idRestaurante = 0;
            }

            ML.RestauranteReceta resultado = BL.RestauranteReceta.GetAll(idRestaurante.Value);

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
