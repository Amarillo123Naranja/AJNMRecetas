using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Categoria
    {
        public int IdCategoria { get; set; }    

        public string Nombre { get; set; }  

        public bool Correct { get; set; }   

        public Object Object { get; set; }  

        public List<Object> Objects { get; set; }   


    }
}
