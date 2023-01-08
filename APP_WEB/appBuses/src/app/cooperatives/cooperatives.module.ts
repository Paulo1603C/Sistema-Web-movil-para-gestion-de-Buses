import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CooperativesRoutingModule } from './cooperatives-routing.module';
import { CooperativesPageComponent } from './pages/cooperatives-page/cooperatives-page.component';
import { RouterModule } from '@angular/router';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { ModalComponent } from './components/modal/modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CooperativesPageComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    CooperativesRoutingModule,
    RouterModule,
    CoreModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class CooperativesModule { }
