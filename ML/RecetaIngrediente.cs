using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class RecetaIngrediente
    {
        public ML.Receta Receta { get; set; }   

        public ML.Ingrediente Ingrediente { get; set; }

        public bool Correct { get; set; }   

        public Object Object { get; set; }  

        public List<Object> Objects { get; set; }   

    }
}
