import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrecuenciaBusRoutingModule } from './frecuencia-bus-routing.module';
import { PageFrecuenciabusComponent } from './pages/page-frecuenciabus/page-frecuenciabus.component';
import { ModalComponent } from './components/modal/modal.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PageFrecuenciabusComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    FrecuenciaBusRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class FrecuenciaBusModule { }
