import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AsientosRoutingModule } from './asientos-routing.module';
import { PageAsientoComponent } from './pages/page-asiento/page-asiento.component';
import { ModalComponent } from './components/modal/modal.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PageAsientoComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    AsientosRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AsientosModule { }
