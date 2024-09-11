using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Producto
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string IdProveedor { get; set; } // Nullable porque en la tabla es NULL
        public string IdCategoria { get; set; } // Nullable porque en la tabla es NULL
        public string CantidadPorUnidad { get; set; }
        public string PrecioUnidad { get; set; } // Nullable porque en la tabla es NULL
        public string UnidadesEnExistencia { get; set; } // Nullable porque en la tabla es NULL
        public string UnidadesEnPedido { get; set; } // Nullable porque en la tabla es NULL
        public string NivelNuevoPedido { get; set; } // Nullable porque en la tabla es NULL
        public string Suspendido { get; set; } // Nullable porque en la tabla es NULL, y se usa smallint para representar booleano
        public string CategoriaProducto { get; set; }
    }
}
