import { Component, OnInit } from '@angular/core';
import { CategoriasService } from '../categorias.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  productoBd: any[] = [];
  categoriaBd: any[] = [];
  idCat: number;
  constructor(public categoriasServ: CategoriasService, public router: Router) { }

  ngOnInit() {

    // this.onLoadProductos();
    // this.onLoadProductosPorCategorias();
    this.onLoadCategorias();
  }


  onLoadProductosPorCategorias() {

    this.categoriasServ.cargarProductosPorCategoria(this.idCat).subscribe((resp: any) => {
      console.log(resp);

      for (let index = 0; index < resp.length; index++) {
        this.categoriaBd[index] = resp[index];
      }
      console.log(this.categoriaBd);
    });
  }

  onLoadProductos() {
    this.categoriasServ.cargarProductos().subscribe((resp: any) => {
      for (let index = 0; index < resp.length; index++) {
        this.categoriaBd[index] = resp[index];
      }
    });
  }

  onLoadCategorias() {
    this.categoriasServ.cargarCategorias().subscribe((resp: any) => {
      
      for (let index = 0; index < resp.length; index++) {
        this.categoriaBd[index] = resp[index];
      }
    });
  }

}
