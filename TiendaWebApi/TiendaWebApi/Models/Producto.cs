using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaWebApi.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public byte[] Imagen { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Producto> eProducto)
            {
                eProducto.HasKey(x => x.ProductoId);
                eProducto.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(50);
                eProducto.Property(x => x.Descripcion).HasColumnName("Descripcion").HasMaxLength(100);
                eProducto.Property(x => x.Precio).HasColumnName("Precio").HasColumnType("money");
                eProducto.Property(x => x.Imagen).HasColumnName("Imagen").HasColumnType("image");
                eProducto.Property(x => x.CategoriaId).HasColumnName("CategoriaId").HasColumnType("int");
                eProducto.HasOne(x => x.Categoria);
            }
        }
    }

    

}
