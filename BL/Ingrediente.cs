using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Ingrediente
    {
        public static Dictionary<string, object> Add(ML.Ingrediente ingrediente)
        {
            var response = new Dictionary<string, object>
            {
                {"isCorrect", false },
                {"message", "" }
            };
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.IngredientesAdd(ingrediente.Nombre, ingrediente.IdPais, ingrediente.Imagen, ingrediente.IdCategoria);
                    if (query > 0)
                    {
                        response["isCorrect"] = true;
                        response["message"] = "Ingrediente insertado correctamente";
                    }
                    else
                    {
                        response["isCorrect"] = false;
                        response["message"] = "No se logro insertar el ingrediente";
                    }
                }
            }
            catch (Exception e)
            {
                response["isCorrect"] = false;
                response["message"] = e.Message;
            }

            return response;
        }

        public static Dictionary<string, object> Update(ML.Ingrediente ingrediente)
        {
			var response = new Dictionary<string, object>
			{
				{"isCorrect", false },
				{"message", "" }
			};
			try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.IngredienteUpdate(ingrediente.IdIngrediente, ingrediente.Nombre, ingrediente.IdPais, ingrediente.Imagen, ingrediente.IdCategoria);
                    if (query > 0)
                    {
                        response["isCorrect"] = true;
                        response["message"] = "La información del ingrediente se actualizo correctamente";
                    }
                    else
                    {
                        response["isCorrect"] = false;
                        response["message"] = "No se pudo actualizar la información del ingrediente";
                    }
                }
            }
            catch (Exception e)
            {
                response["isCorrect"] = false;
                response["message"] = e.Message;
            }
            return response;
        }

        public static Dictionary<string, object> Delete(int idIngrediente)
        {
            var response = new Dictionary<string, object>
            {
                { "isCorrect", false},
                { "message", string.Empty }
            };
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.IngredienteDelete(idIngrediente);
                    if (query > 0)
                    {
                        response["isCorrect"] = true;
                        response["message"] = "Ingrediente eliminado correctamente";
                    }
                    else
                    {
                        response["isCorrect"] = false;
                        response["message"] = "No se logró eliminar el ingrediente";
                    }
                }
            }
            catch (Exception e)
            {
                response["isCorrect"] = false;
                response["message"] = e.Message;
            }
            return response;
        }
        public static Dictionary<string, object> GetAll(string nombre)
        {
            var response = new Dictionary<string, object>
            {
                { "isCorrect", false},
                { "message", string.Empty },
                { "values", new List<object>()}
            };
            List<object> lista = new List<object>();
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.IngredienteGetAll(nombre).ToList();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Ingrediente ingrediente = new ML.Ingrediente
                            {
                                IdIngrediente = obj.IdIngrediente,
                                Nombre = obj.Nombre,
                                Imagen = obj.Imagen,
                                Pais = new ML.Pais
                                {
                                    IdPais = (int)obj.IdPais,
                                    Nombre = obj.NombrePais
                                },
                                Categoria = new ML.Categoria
                                {
                                    IdCategoria = (int)obj.IdCategoria,
                                    Nombre = obj.NombreCategoria
                                }
                            };
                            lista.Add(ingrediente);
                        }
                        response["isCorrect"] = true;
                        response["message"] = "Lista de ingredientes cargada";
                        response["values"] = lista;
                    }
                    else
                    {
                        response["isCorrect"] = false;
                        response["message"] = "No se encontrarón ingredientes";
                    }
                }
            }
            catch (Exception e)
            {
                response["isCorrect"] = false;
                response["message"] = e.Message;
            }
            return response;
        }

        public static Dictionary<string, object> GetById(int idIngrediente)
        {
            var response = new Dictionary<string, object>
            {
                { "isCorrect", false},
                { "message", string.Empty },
                { "value", null}
            };
            try
            {
                using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.IngredienteGetById(idIngrediente).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Ingrediente ingrediente = new ML.Ingrediente
                        {
                            IdIngrediente = query.IdIngrediente,
                            Nombre = query.Nombre,
                            Imagen = query.Imagen,
                            Pais = new ML.Pais
                            {
                                IdPais = (int)query.IdPais,
                                Nombre = query.NombrePais
                            },
                            Categoria = new ML.Categoria
                            {
                                IdCategoria = (int)query.IdCategoria,
                                Nombre = query.NombreCategoria
                            }
                        };
                        response["isCorrect"] = true;
                        response["message"] = "Ingrediente encontrado";
                        response["value"] = ingrediente;
                    }
                    else
                    {
                        response["isCorrect"] = false;
                        response["message"] = $"No se encontro el ingrediente con el ID {idIngrediente}";
                    }
                }
            }
            catch (Exception e)
            {
                response["isCorrect"] = false;
                response["message"] = e.Message;
            }
            return response;
        }
    }
}
