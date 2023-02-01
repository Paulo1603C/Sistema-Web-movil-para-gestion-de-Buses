import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CooperativesModule } from './cooperatives.module';
import { CooperativesPageComponent } from './pages/cooperatives-page/cooperatives-page.component';

const routes: Routes = [
  {path: '', component:CooperativesPageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CooperativesRoutingModule { }
