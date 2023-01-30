import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BusesRoutingModule } from './buses-routing.module';
import { BusesPageComponent } from './pages/buses-page/buses-page.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { ModalComponent } from './components/modal/modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CooperativeService } from '../cooperatives/service/cooperative.service';


@NgModule({
  declarations: [
    BusesPageComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    BusesRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ], providers:[
    CooperativeService
  ]
})
export class BusesModule { }
