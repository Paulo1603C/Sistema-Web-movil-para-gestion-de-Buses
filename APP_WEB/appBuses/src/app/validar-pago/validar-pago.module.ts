import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ValidarPagoRoutingModule } from './validar-pago-routing.module';
import { PageValidarpagoComponent } from './pages/page-validarpago/page-validarpago.component';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PageValidarpagoComponent
  ],
  imports: [
    CommonModule,
    ValidarPagoRoutingModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ValidarPagoModule { }
