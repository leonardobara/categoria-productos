using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaWebApi.Models;
using TiendaWebApi.DTOs;

namespace TiendaWebApi.Services
{
    public class CategoriaService
    {
        public readonly TiendaDBContext _TiendaContext;
        public CategoriaService(TiendaDBContext TiendaDB)
        {
            _TiendaContext = TiendaDB;
        }

        //public List<Categoria> verListadoCategorias()
        //{
        //    var categoriaBuscada = _TiendaContext.Categoria.Include(x => x.Productos).ToList();

        //    return categoriaBuscada;
        //}

        public List<Categoria> verListadoCategorias()
        {
            var categoriaBuscada = _TiendaContext.Categoria.OrderBy(x => x.Nombre).ToList();

            return categoriaBuscada;
        }


        public List<Producto> verListadoProductos()
        {
            var productoBuscado = _TiendaContext.Producto.Include(x => x.Categoria).ToList();

            return productoBuscado;
        }

        public void agregaProducto(Producto producto)
        {
            _TiendaContext.Producto.Add(producto);
            _TiendaContext.SaveChanges();
            
        }

        public void agregaCategoria(Categoria categoria)
        {
            _TiendaContext.Categoria.Add(categoria);
            _TiendaContext.SaveChanges();

        }

        public void editarCategoria(Categoria categoriaEditar)
        {
            var categoria = _TiendaContext.Categoria.FirstOrDefault(x => x.CategoriaId == categoriaEditar.CategoriaId);

            categoria.Nombre = categoriaEditar.Nombre;
            categoria.Descripcion = categoriaEditar.Descripcion;
            _TiendaContext.SaveChanges();
        }

        public List<ProductoPorCategoriaDTO> verProductosFiltradosPorCategoriaDelMasBaratoAlCaro(int id)
        {
            //var listadoProductos = (from c in _TiendaContext.Categoria
            //                        join p in _TiendaContext.Producto on c.CategoriaId equals p.CategoriaId
            //                        select new 
            //                        {
            //                            IdCAT = c.CategoriaId,
            //                            Nom = c.Nombre,
            //                            s = c.Descripcion,
            //                            x = p.ProductoId,
            //                            a = p.Nombre,
            //                            f = p.Descripcion,
            //                            q = p.Precio,
            //                            b = p.Imagen,
            //                            z = p.CategoriaId

            //                        }).ToList();

            var listadoProductos = (from p in _TiendaContext.Producto.Include(x => x.Categoria)
                                    orderby p.Precio ascending
                                    select new ProductoPorCategoriaDTO
                                    {
                                        ProductoId = p.ProductoId,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        Precio = p.Precio,
                                        Imagen = p.Imagen,
                                        CategoriaId = p.CategoriaId,
                                        NombreCategoria = p.Categoria.Descripcion

                                    }).Where(x => x.CategoriaId == id).ToList();

            


            //var listadoProductos = _TiendaContext.Categoria.Join(_TiendaContext.Producto,
            //                        c => c.CategoriaId,
            //                        p => p.CategoriaId,
            //                        (c, p) => new
            //                        {

            //                            IdCAT = c.CategoriaId,
            //                            Nom = c.Nombre,
            //                            s = c.Descripcion,
            //                            x = p.ProductoId,
            //                            a = p.Nombre,
            //                            f = p.Descripcion,
            //                            q = p.Precio,
            //                            b = p.Imagen,
            //                            z = p.CategoriaId

            //                        }).ToList();


            return listadoProductos;
        }

        public List<ProductoPorCategoriaDTO> verProductosFiltradosPorCategoriaPrecioEntre(int id, int menor, int mayor)
        {
          

            var listadoProductos = (from p in _TiendaContext.Producto.Include(x => x.Categoria)
                                    where p.Precio >= menor 
                                    where p.Precio <= mayor
                                    select new ProductoPorCategoriaDTO
                                    {
                                        ProductoId = p.ProductoId,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        Precio = p.Precio,
                                        Imagen = p.Imagen,
                                        CategoriaId = p.CategoriaId,
                                        NombreCategoria = p.Categoria.Descripcion
                                    }).Where(x => x.CategoriaId == id).ToList();
            return listadoProductos;
        }

        public List<ProductoPorCategoriaDTO> verProductosFiltradosPorPrecioAltoAlBajo(int id)
        {

            var listadoProductos = (from p in _TiendaContext.Producto.Include(x => x.Categoria)
                                    orderby p.Precio descending
                                    select new ProductoPorCategoriaDTO
                                    {
                                        ProductoId = p.ProductoId,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        Precio = p.Precio,
                                        Imagen = p.Imagen,
                                        CategoriaId = p.CategoriaId,
                                        NombreCategoria = p.Categoria.Descripcion
                                    }).Where(x => x.CategoriaId == id).ToList();
            return listadoProductos;
        }

        public List<ProductoPorCategoriaDTO> verProductosFiltradosPorNombreAaZ(int id)
        {

            var listadoProductos = (from p in _TiendaContext.Producto.Include(x => x.Categoria)
                                    orderby p.Nombre ascending
                                    select new ProductoPorCategoriaDTO
                                    {
                                        ProductoId = p.ProductoId,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        Precio = p.Precio,
                                        Imagen = p.Imagen,
                                        CategoriaId = p.CategoriaId,
                                        NombreCategoria = p.Categoria.Descripcion
                                    }).Where(x => x.CategoriaId == id).ToList();
            return listadoProductos;
        }

        public List<ProductoPorCategoriaDTO> verProductosFiltradosPorNombreZaA(int id)
        {

            var listadoProductos = (from p in _TiendaContext.Producto.Include(x => x.Categoria)
                                    orderby p.Nombre descending
                                    select new ProductoPorCategoriaDTO
                                    {
                                        ProductoId = p.ProductoId,
                                        Nombre = p.Nombre,
                                        Descripcion = p.Descripcion,
                                        Precio = p.Precio,
                                        Imagen = p.Imagen,
                                        CategoriaId = p.CategoriaId,
                                        NombreCategoria = p.Categoria.Descripcion
                                    }).Where(x => x.CategoriaId == id).ToList();
            return listadoProductos;
        }

    }
}
