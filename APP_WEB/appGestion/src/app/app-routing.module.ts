import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/pages/login/login.component';


const routes: Routes = [
  {path : '', component:LoginComponent},
  {path : 'cooperativas', loadChildren:() => import('./cooperatives/cooperatives.module').then(m => m.CooperativesModule)},
  {path : 'buses', loadChildren:() => import('./buses/buses.module').then(m => m.BusesModule)},
  {path : 'frecuencias', loadChildren:() => import('./frequencies/frequencies.module').then(m => m.FrequenciesModule)},
  {path : 'usuarios', loadChildren:() => import('./usuarios/usuarios.module').then(m => m.UsuariosModule)},
  {path : 'rutas', loadChildren:() => import('./rutas/rutas.module').then(m => m.RutasModule)},
  {path : 'frecuenciabus', loadChildren:() => import('./frecuencia-bus/frecuencia-bus.module').then(m => m.FrecuenciaBusModule)},
  {path : 'validarpago', loadChildren:() => import('./validar-pago/validar-pago.module').then(m => m.ValidarPagoModule)},
  {path : 'asientos', loadChildren:() => import('./asientos/asientos.module').then(m => m.AsientosModule)},
  {path : 'asientos/:IdBus', loadChildren:() => import('./asientos/asientos.module').then(m => m.AsientosModule)},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
