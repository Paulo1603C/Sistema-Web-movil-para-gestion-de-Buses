import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusesPageComponent } from './pages/buses-page/buses-page.component';

const routes: Routes = [
  {path: '', component:BusesPageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BusesRoutingModule { }
