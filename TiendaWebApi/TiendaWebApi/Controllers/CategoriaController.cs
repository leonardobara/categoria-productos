using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaWebApi.Models;
using TiendaWebApi.Services;

namespace TiendaWebApi.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _TiendaService;
        public CategoriaController(CategoriaService TiendaService)
        {
            _TiendaService = TiendaService;
        }

        [HttpGet("ver-categorias")]
        public IActionResult verCategoriasProductos()
        {
            var listadoCategorias = _TiendaService.verListadoCategorias();
            return Ok(listadoCategorias);
        }

        [Route("ver-productos")]
        [HttpGet]
        public IActionResult verProductos()
        {
            var listadoProductos = _TiendaService.verListadoProductos();
            return Ok(listadoProductos);
        }

        [HttpGet("ver-filtrado")]
        public IActionResult verProductoFiltrado([FromQuery] int id)
        {
            var listado = _TiendaService.verProductosFiltradosPorCategoriaDelMasBaratoAlCaro(id);
            return Ok(listado);
        }

        [Route("ver-filtrado2/{id}/{menor}/{mayor}")]
        [HttpGet]
        public IActionResult verProductoFiltrado2(int id, int menor, int mayor)
        {
            var listado = _TiendaService.verProductosFiltradosPorCategoriaPrecioEntre(id, menor, mayor);
            return Ok(listado);
        }

        [Route("ver-filtradoPrecio/{id}")]
        [HttpGet]
        public IActionResult verFiltradoPorPrecioDescending(int id)
        {
            var listado = _TiendaService.verProductosFiltradosPorPrecioAltoAlBajo(id);
            return Ok(listado);
        }

        [Route("ver-filtradoNombreAsc/{id}")]
        [HttpGet]
        public IActionResult verFiltradoPorNombreAscending(int id)
        {
            var listado = _TiendaService.verProductosFiltradosPorNombreAaZ(id);
            return Ok(listado);
        }

        [Route("ver-filtradoNombreDesc/{id}")]
        [HttpGet]
        public IActionResult verFiltradoPorNombreDescending(int id)
        {
            var listado = _TiendaService.verProductosFiltradosPorNombreZaA(id);
            return Ok(listado);
        }

        [Route("agregar-producto")]
        [HttpPost]

        public IActionResult agregarProducto([FromBody] Producto producto)
        {
            _TiendaService.agregaProducto(producto);

            if (true)
            {
                return Ok("Agregado el Producto!");
            }
        }

        [Route("agregar-categoria")]
        [HttpPost]

        public IActionResult agregarCategoria([FromBody] Categoria categoria)
        {
            _TiendaService.agregaCategoria(categoria);

            if (true)
            {
                return Ok("Agregada la Categoria!");
            }
        }

        [Route("editar-categoria")]
        [HttpPut]
        public IActionResult editarCategoria([FromBody] Categoria categoria)
        {
            _TiendaService.editarCategoria(categoria);

            return Ok("Actualizada la categoria");
        }
    }
}