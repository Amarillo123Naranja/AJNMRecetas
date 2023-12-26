using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Receta
    {

        public int IdReceta { get; set; }   

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; } 

        public int IdIngediente { get; set; }   

        public int IdPais { get; set; } 

        public string Imagen { get; set; }

        public int Porcion { get; set; }    

        public ML.Ingrediente Ingrediente { get; set; } 

        public ML.Pais Pais { get; set; }   
        
        public bool Correct { get; set; }

        public Object Object { get; set; }  

        public List<Object> Objects { get; set; }   



    }
}
