using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {

        public static ML.Categoria GetAll()
        {
            ML.Categoria resultado = new ML.Categoria(); 
            
            try
            {
                using(DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {
                    var query = context.CategoriaGetAll().ToList();

                    resultado.Objects = new List<Object>();

                    if(query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();

                            categoria.IdCategoria = registro.IdCategoria;

                            categoria.Nombre = registro.Nombre;

                            resultado.Objects.Add(categoria);

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
