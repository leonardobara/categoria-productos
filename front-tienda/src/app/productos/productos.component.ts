import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { CategoriasService } from '../categorias.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {

  public id;
  idOrden: number;
  desde: number;
  hasta: number;
  products: any[] = [];
  constructor(public actRoute: ActivatedRoute, public categoriasServ: CategoriasService, public router: Router) { }

  ngOnInit() {
    this.id = this.actRoute.snapshot.paramMap.get('id');
    this.traerProduct();
  }

  traerProduct() {
    this.categoriasServ.cargarProductosPorCategoria(this.id).subscribe(
      (resp: any) => {
        for (let index = 0; index < resp.length; index++) {
          this.products[index] = resp[index];
        }
        console.log(resp);
      });

  }

  cambioOrden() {
    console.log(this.idOrden);
    

    if (this.idOrden == 1) {
      this.categoriasServ.cargarProductosFiltradosPorNombreAscending(this.id).subscribe( (resp: any) => {
          this.products = resp;
      });
    }
    

    if (this.idOrden == 2) {
      this.categoriasServ.cargarProductosFiltradosPorNombreDescending(this.id).subscribe( (resp: any) => {
          this.products = resp;
      });
    }

    if (this.idOrden == 4) {
      this.categoriasServ.cargarProductosFiltradosPorPrecioDescending(this.id).subscribe( (resp: any) => {
          this.products = resp;
          
      });
    }

  }

  filtrarPorRangoPrecios() {
    this.categoriasServ.cargarProductosFiltradosPorRangoDePrecio(this.id ,this.desde, this.hasta).subscribe( (resp: any) => {
      this.products = resp;
  });
    
  }

  onBack() {
    this.router.navigate(['/categorias']);
  }

}
