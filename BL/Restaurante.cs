using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class Restaurante
    {
        public static bool Add(ML.Restaurante restaurante)
        {
            bool result=new bool();

            using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
            {
                var rowAffeted = context.RestauranteAdd(
                    restaurante.Nombre,
                    restaurante.Imagen,
                    restaurante.Direccion,
                    restaurante.Calificacion,
                    restaurante.Pais.IdPais
                    );

                if(rowAffeted > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public static bool Update(ML.Restaurante restaurante)
        {
            bool result=new bool();

            using (DL.AJNMRecetasEntities context =  new DL.AJNMRecetasEntities())
            {
                var rowAffected = context.RestauranteUpdate(
                    restaurante.IdRestaurante,
                    restaurante.Nombre,
                    restaurante.Imagen,
                    restaurante.Direccion,
                    restaurante.Calificacion,
                    restaurante.Pais.IdPais
                    );

                if(rowAffected > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool Delete(int IdRestaurente)
        {
            bool result=new bool();

            using (DL.AJNMRecetasEntities context =  new DL.AJNMRecetasEntities())
            {
                int rowAffected = context.RestauranteDelete(IdRestaurente);

                if(rowAffected > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public static object GetbyId(int IdRestaurante)
        {
            object result = new object();

            using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
            {
                var query = context.RestauranteGetByID(IdRestaurante).SingleOrDefault();

                if(query != null)
                {
                    ML.Restaurante restaurante = new ML.Restaurante();
                    restaurante.Pais = new ML.Pais();

                    restaurante.IdRestaurante = query.IdRestaurante;
                    restaurante.Nombre = query.Nombre;
                    restaurante.Imagen = query.Imagen;
                    restaurante.Direccion = query.Dirección;
                    restaurante.Calificacion = (int)query.Calificacion;
                    restaurante.Pais.IdPais = (int)query.IdPais;
                    restaurante.Pais.Nombre = query.PaisNombre;

                    result = restaurante;
                }
            }
            return result;
        }

        public static List<object> GetAll(string pais, string receta,int? calificacion)
        {
            List<object> result = new List<object>();

            using (DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
            {
                var query = context.RestauranteGetAll(pais,receta,calificacion).ToList();

                if(query != null)
                {
                    foreach (var item in query)
                    {
                        ML.Restaurante restaurante = new ML.Restaurante();
                        restaurante.Receta = new ML.Receta();
                        restaurante.Pais=new ML.Pais();


                        restaurante.IdRestaurante = (int)item.IdRestaurante;
                        restaurante.Receta.IdReceta = (int)item.IdReceta;
                        restaurante.Pais.IdPais = (int)item.IdPais;
                        restaurante.Pais.Nombre = item.PaisNombre;
                        restaurante.Calificacion = (int)item.Calificacion;
                        restaurante.Receta.Nombre = item.NombreReceta;

                        result.Add(restaurante);
                    }
                }
            }
            return result;
        }
    }
}
