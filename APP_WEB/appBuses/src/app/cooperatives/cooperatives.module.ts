import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CooperativesRoutingModule } from './cooperatives-routing.module';
import { CooperativesPageComponent } from './pages/cooperatives-page/cooperatives-page.component';


@NgModule({
  declarations: [
    CooperativesPageComponent
  ],
  imports: [
    CommonModule,
    CooperativesRoutingModule
  ]
})
export class CooperativesModule { }
