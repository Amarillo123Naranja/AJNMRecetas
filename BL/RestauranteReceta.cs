using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RestauranteReceta
    {
        public static ML.RestauranteReceta GetAll(int idRestaurante)
        {
            ML.RestauranteReceta resultado = new ML.RestauranteReceta(); 
            
            try
            {
                using(DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {

                    var query = context.RestauranteRecetaGetAll(idRestaurante).ToList();

                    resultado.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.RestauranteReceta aux = new ML.RestauranteReceta();

                            aux.Receta = new ML.Receta();

                            aux.Receta.IdReceta = registro.IdReceta.Value;

                            aux.Restaurante = new ML.Restaurante();

                            aux.Restaurante.IdRestaurante = registro.IdRestaurante.Value;

                            aux.Receta.Descripcion = registro.Descripcion;

                            aux.Receta.Porcion = registro.Porcion.Value;

                            aux.Receta.Imagen = registro.RecetaImagen;

                            aux.Restaurante.Pais = new ML.Pais();

                            aux.Restaurante.Pais.IdPais = registro.IdPais.Value;

                            aux.Restaurante.Pais.Nombre = registro.PaisNombre;

                            aux.Restaurante.Direccion = registro.Dirección;

                            aux.Restaurante.Imagen = registro.RecetaImagen;

                            aux.Restaurante.Nombre = registro.RestauranteNombre;

                            aux.Restaurante.Calificacion = registro.Calificacion.Value;

                            aux.Receta.Nombre = registro.NombreReceta;

                            resultado.Objects.Add(aux);
                        }

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
