using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Categoria
    {
        public string IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; } // Nullable porque en la tabla es NULL
        public string Activo { get; set; } // Nullable porque en la tabla es NULL
        public string CodCategoria { get; set; }        
    }
}
