import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RutasRoutingModule } from './rutas-routing.module';
import { PageRutaComponent } from './pages/page-ruta/page-ruta.component';
import { ModalComponent } from './components/modal/modal.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PageRutaComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    RutasRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RutasModule { }
