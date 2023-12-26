using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }

        public string Nombre { get; set; }

        public int IdPais { get; set; }

        public string Imagen { get; set; }

        public int IdCategoria { get; set; }

        public ML.Pais Pais { get; set; }

        public ML.Categoria Categoria {get; set;}

        public bool Correct { get; set; }







    }
}
