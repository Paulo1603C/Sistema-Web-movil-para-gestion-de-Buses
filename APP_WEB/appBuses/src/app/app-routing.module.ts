import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './core/pages/login/login.component';


const routes: Routes = [
  {path : '', component:LoginComponent},
  {path : 'cooperativas', loadChildren:() => import('./cooperatives/cooperatives.module').then(m => m.CooperativesModule)},
  {path : 'buses', loadChildren:() => import('./buses/buses.module').then(m => m.BusesModule)},
  {path : 'frecuencias', loadChildren:() => import('./frequencies/frequencies.module').then(m => m.FrequenciesModule)},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
