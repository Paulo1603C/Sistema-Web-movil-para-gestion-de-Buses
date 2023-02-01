import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageValidarpagoComponent } from './pages/page-validarpago/page-validarpago.component';

const routes: Routes = [
  {path: '', component:PageValidarpagoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ValidarPagoRoutingModule { }
