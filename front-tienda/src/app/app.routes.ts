import { Routes, RouterModule } from '@angular/router';
import { CategoriasComponent } from './categorias/categorias.component';
import { ProductosComponent } from './productos/productos.component';

// Componentes



const appRoutes: Routes = [

    { path: 'categorias', component: CategoriasComponent },
    { path: 'productos/:id', component: ProductosComponent },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }

];


export const APP_ROUTES = RouterModule.forRoot(appRoutes, { useHash: true });