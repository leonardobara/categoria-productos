using Microsoft.EntityFrameworkCore;
using TiendaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaWebApi
{
    public class TiendaDBContext: DbContext
    {
        public TiendaDBContext(DbContextOptions opciones): base(opciones)
        {

        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Categoria.Map(modelB.Entity<Categoria>());
            new Producto.Map(modelB.Entity<Producto>());
            base.OnModelCreating(modelB);
        }  

    }
}
