import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IsLoggedInGuard } from './core/guards/is-logged-in.guard';
import { LoginComponent } from './core/pages/login/login.component';


const routes: Routes = [
  {path : '', component:LoginComponent,data:{roles:[1,2,3,4,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'cooperativas', loadChildren:() => import('./cooperatives/cooperatives.module').then(m => m.CooperativesModule),data:{roles:[3,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'buses', loadChildren:() => import('./buses/buses.module').then(m => m.BusesModule),data:{roles:[1,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'frecuencias', loadChildren:() => import('./frequencies/frequencies.module').then(m => m.FrequenciesModule),data:{roles:[0,2,3,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'usuarios', loadChildren:() => import('./usuarios/usuarios.module').then(m => m.UsuariosModule),data:{roles:[1,3,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'rutas', loadChildren:() => import('./rutas/rutas.module').then(m => m.RutasModule),data:{roles:[3,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'frecuenciabus', loadChildren:() => import('./frecuencia-bus/frecuencia-bus.module').then(m => m.FrecuenciaBusModule),data:{roles:[1,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'validarpago', loadChildren:() => import('./validar-pago/validar-pago.module').then(m => m.ValidarPagoModule),data:{roles:[4,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'asientos', loadChildren:() => import('./asientos/asientos.module').then(m => m.AsientosModule),data:{roles:[1,6]}, canActivate:[IsLoggedInGuard]},
  {path : 'asientos/:IdBus', loadChildren:() => import('./asientos/asientos.module').then(m => m.AsientosModule)},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
