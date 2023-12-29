using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetaIngrediente
    {

        public static ML.RecetaIngrediente GetbyId(int idReceta)
        {

            ML.RecetaIngrediente resultado = new ML.RecetaIngrediente();

            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaIngredientesGetAll(idReceta).SingleOrDefault();

                    resultado.Object = new List<Object>();

                    if (query != null)
                    {
                        
                            ML.RecetaIngrediente aux = new ML.RecetaIngrediente();

                            aux.Receta = new ML.Receta();

                            aux.Receta.IdReceta = query.IdReceta.Value;

                            aux.Ingrediente = new ML.Ingrediente();

                            aux.Ingrediente.IdIngrediente = query.IdIngrediente.Value;

                            aux.Receta.Nombre = query.RecetaNombre;

                            aux.Receta.Descripcion = query.Descripcion;

                            aux.Receta.Imagen = query.RecetaImagen;

                            aux.Receta.Porcion = query.Porcion.Value;

                            aux.Ingrediente.Nombre = query.IngredienteNombre;

                            aux.Ingrediente.Imagen = query.ImagenIngrediente;

                            aux.Ingrediente.Pais = new ML.Pais();

                            aux.Ingrediente.Pais.IdPais = query.IdPais.Value;

                            aux.Ingrediente.Categoria = new ML.Categoria();

                            aux.Ingrediente.Categoria.IdCategoria = query.IdCategoria.Value;

                            aux.Ingrediente.Pais.Nombre = query.NombrePais;

                            aux.Ingrediente.Categoria.Nombre = query.NombreCategoria;

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
