import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BusesRoutingModule } from './buses-routing.module';
import { BusesPageComponent } from './pages/buses-page/buses-page.component';


@NgModule({
  declarations: [
    BusesPageComponent
  ],
  imports: [
    CommonModule,
    BusesRoutingModule
  ]
})
export class BusesModule { }
