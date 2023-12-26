using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RestauranteReceta
    {
        public ML.Restaurante Restaurante { get; set; }

        public ML.Receta Receta { get; set; }

        public bool Correct { get; set; }   

        public Object Object { get; set; }  

        public List<Object> Objects { get; set; }   

    }
}
