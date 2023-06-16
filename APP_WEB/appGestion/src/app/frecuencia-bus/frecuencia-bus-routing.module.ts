import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageFrecuenciabusComponent } from './pages/page-frecuenciabus/page-frecuenciabus.component';

const routes: Routes = [
  {path: '', component:PageFrecuenciabusComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FrecuenciaBusRoutingModule { }
