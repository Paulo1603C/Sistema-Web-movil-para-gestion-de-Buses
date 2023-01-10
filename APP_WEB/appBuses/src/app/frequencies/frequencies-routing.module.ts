import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrequenciesPageComponent } from './pages/frequencies-page/frequencies-page.component';

const routes: Routes = [
  {path: '', component:FrequenciesPageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FrequenciesRoutingModule { }
