using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendasSiSitio.Models
{
    public class Producto
    {

        public int id { get; set; }
        public string nombreProducto { get; set; }
        public string detalleProducto { get; set; }
        public int idTipoProducto { get; set; }
        public bool estadoProducto { get; set; }
    }
}
