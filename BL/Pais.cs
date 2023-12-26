using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {

       public static ML.Pais GetAll()
        {
            ML.Pais resultado = new ML.Pais(); try
            {
                using(DL.AJNMRecetasEntities context = new DL.AJNMRecetasEntities())
                {

                    var query = context.PaisGetAll().ToList();

                    resultado.Objects = new List<Object>(); 

                    if(query != null)
                    {
                        foreach(var registro in query)
                        {

                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = registro.IdPais;

                            pais.Nombre = registro.Nombre;

                            resultado.Objects.Add(pais);

                        }

                        resultado.Correct = true;

                    }



                }
            } 
            catch (Exception ex) 
            {
                resultado.Correct = false;
 
            }

            return resultado;

        } 



    }
}
