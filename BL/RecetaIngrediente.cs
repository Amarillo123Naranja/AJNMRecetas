using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetaIngrediente
    {

        public static ML.RecetaIngrediente GetAll(int idReceta)
        {

            ML.RecetaIngrediente resultado = new ML.RecetaIngrediente();

            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaIngredientesGetAll(idReceta).ToList();

                    resultado.Objects = new List<Object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.RecetaIngrediente aux = new ML.RecetaIngrediente();

                            aux.Receta = new ML.Receta();

                            aux.Receta.IdReceta = registro.IdReceta.Value;

                            aux.Ingrediente = new ML.Ingrediente();

                            aux.Ingrediente.IdIngrediente = registro.IdIngrediente.Value;

                            aux.Receta.Nombre = registro.RecetaNombre;

                            aux.Receta.Descripcion = registro.Descripcion;

                            aux.Receta.Imagen = registro.RecetaImagen;

                            aux.Receta.Porcion = registro.Porcion.Value;

                            aux.Ingrediente.Nombre = registro.IngredienteNombre;

                            aux.Ingrediente.Imagen = registro.ImagenIngrediente;

                            aux.Ingrediente.Pais = new ML.Pais();

                            aux.Ingrediente.Pais.IdPais = registro.IdPais.Value;

                            aux.Ingrediente.Categoria = new ML.Categoria();

                            aux.Ingrediente.Categoria.IdCategoria = registro.IdCategoria.Value;

                            aux.Ingrediente.Pais.Nombre = registro.NombrePais;

                            aux.Ingrediente.Categoria.Nombre = registro.NombreCategoria;

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
