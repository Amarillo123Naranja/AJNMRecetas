using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Restaurante
    {
        public int IdRestaurante { get; set; }

        public string Nombre { get; set; }  

        public string Imagen { get; set;}

        public string Direccion { get; set; }

        public int Calificacion { get; set; }   

        public int IdPais { get; set; } 

        public int IdReceta { get; set; }   

        public ML.Pais Pais { get; set; }   

        public ML.Receta Receta { get; set; }   

        public bool Correct { get; set; }

        public Object Object { get; set; }  

        public List<Object> Objects { get; set; }   

    }
}
