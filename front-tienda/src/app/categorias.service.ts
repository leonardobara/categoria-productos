import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { tap, catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  urlGlobal = 'http://localhost:52038/api/categorias/';
  constructor(public http: HttpClient) { }


  cargarProductosPorCategoria(id: number) 
  {
    return this.http.get(`${this.urlGlobal}ver-filtrado?id=${id}`);
  }

  cargarProductos() 
  {
    return this.http.get(`${this.urlGlobal}ver-productos`);
  }

  cargarCategorias() 
  {
    return this.http.get(`${this.urlGlobal}ver-categorias`);
  }

  cargarProductosFiltradosPorPrecioDescending(id: number) 
  {
    return this.http.get(`${this.urlGlobal}ver-filtradoPrecio/${id}`);
  }

  cargarProductosFiltradosPorNombreAscending(id: number) 
  {
    return this.http.get(`${this.urlGlobal}ver-filtradoNombreAsc/${id}`);
  }

  cargarProductosFiltradosPorNombreDescending(id: number) 
  {
    return this.http.get(`${this.urlGlobal}ver-filtradoNombreDesc/${id}`);
  }

  cargarProductosFiltradosPorRangoDePrecio(id: number, desde: number, hasta: number) 
  {
    return this.http.get(`${this.urlGlobal}ver-filtrado2/${id}/${desde}/${hasta}`);
  }


}
