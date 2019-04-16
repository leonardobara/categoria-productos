using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaWebApi.Models
{
    public class Categoria
    {
        public Categoria()
        {
           // Productos = new List<Producto>();
        }

        public int CategoriaId { get; set; }
        public string Nombre  { get; set; }
        public string Descripcion { get; set; }
        //public Producto Producto { get; set; }
        // public List<Producto> Productos { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Categoria> eCategoria)
            {
                eCategoria.HasKey(x => x.CategoriaId);
                eCategoria.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(50);
                eCategoria.Property(x => x.Descripcion).HasColumnName("Descripcion").HasMaxLength(100);
                // eCategoria.HasMany(x => x.Productos).WithOne(x => x.Categoria).HasForeignKey(x => x.CategoriaId);
            }
        }
    }

    
}
