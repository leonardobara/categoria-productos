using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaWebApi.DTOs
{
    public class ProductoPorCategoriaDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public byte[] Imagen { get; set; }
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
    }
}
