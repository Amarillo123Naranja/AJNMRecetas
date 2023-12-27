using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Receta
    {
        public static ML.Receta GetAll(string nombre, string pais)
        {
            ML.Receta result = new ML.Receta();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaGetAll(nombre, pais).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        foreach (var row in query)
                        {
                            ML.Receta receta = new ML.Receta();
                            receta.Pais = new ML.Pais();

                            receta.Nombre = row.Nombre;
                            receta.Descripcion = row.Descripcion;
                            receta.Pais.IdPais = int.Parse(row.IdPais.ToString());
                            receta.Imagen = row.Imagen;
                            receta.Porcion = int.Parse(row.Porcion.ToString());
                            receta.Pais.Nombre = row.PaisNombre;
                            result.Objects.Add(receta);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("No se pueden mostrar los registros");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public static ML.Receta GetById(int IdReceta)
        {
            ML.Receta result = new ML.Receta();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaGetById(IdReceta).First();
                    if (query != null)
                    {
                        ML.Receta receta = new ML.Receta();
                        receta.Pais = new ML.Pais();

                        receta.Nombre = query.Nombre;
                        receta.Descripcion = query.Descripcion;
                        receta.Pais.IdPais = int.Parse(query.IdPais.ToString());
                        receta.Imagen = query.Imagen;
                        receta.Porcion = int.Parse(query.Porcion.ToString());
                        result.Object = receta;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Error no se puede mostrar la receta");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public static ML.Receta Add(ML.Receta receta)
        {
            ML.Receta result = new ML.Receta();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaAdd(receta.Nombre, receta.Descripcion, receta.Pais.IdPais, receta.Imagen, receta.Porcion);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("No se pudo registar la receta");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public static ML.Receta Update(ML.Receta receta)
        {
            ML.Receta result = new ML.Receta();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaUpdate(receta.IdReceta, receta.Nombre, receta.Descripcion, receta.Pais.IdPais, receta.Imagen, receta.Porcion);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("No se pudo actualizar los campos de la receta");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public static ML.Receta Delete(int IdReceta)
        {
            ML.Receta result = new ML.Receta();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.RecetaDelete(IdReceta);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("No se puedo eliminar la receta");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
