import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageAsientoComponent } from './pages/page-asiento/page-asiento.component';

const routes: Routes = [
  {path: '', component:PageAsientoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AsientosRoutingModule { }
