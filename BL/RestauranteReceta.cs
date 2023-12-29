using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RestauranteReceta
    {
        public static ML.RestauranteReceta GetbyId(int idRestaurante)
        {
            ML.RestauranteReceta resultado = new ML.RestauranteReceta(); 
            
            try
            {
                using(DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {

                    var query = context.RestauranteRecetaGetAll(idRestaurante).SingleOrDefault();

                    resultado.Object = new List<object>();

                    if(query != null)
                    {
                          ML.RestauranteReceta aux = new ML.RestauranteReceta();

                            aux.Receta = new ML.Receta();

                            aux.Receta.IdReceta = query.IdReceta.Value;

                            aux.Restaurante = new ML.Restaurante();

                            aux.Restaurante.IdRestaurante = query.IdRestaurante.Value;

                            aux.Receta.Descripcion = query.Descripcion;

                            aux.Receta.Porcion = query.Porcion.Value;

                            aux.Receta.Imagen = query.RecetaImagen;

                            aux.Restaurante.Pais = new ML.Pais();

                            aux.Restaurante.Pais.IdPais = query.IdPais.Value;

                            aux.Restaurante.Pais.Nombre = query.PaisNombre;

                            aux.Restaurante.Direccion = query.Dirección;

                            aux.Restaurante.Imagen = query.RecetaImagen;

                            aux.Restaurante.Nombre = query.RestauranteNombre;

                            aux.Restaurante.Calificacion = query.Calificacion.Value;

                            aux.Receta.Nombre = query.NombreReceta;

                            resultado.Object = aux;
                        
                            resultado.Correct = true;

                    }

                }

            }
            catch(Exception ex)
            {
                resultado.Correct = false;
            }


            return resultado;


        }


    }
}
