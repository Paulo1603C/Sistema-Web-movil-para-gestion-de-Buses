import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CooperativesRoutingModule } from './cooperatives-routing.module';
import { CooperativesPageComponent } from './pages/cooperatives-page/cooperatives-page.component';
import { RouterModule } from '@angular/router';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    CooperativesPageComponent
  ],
  imports: [
    CommonModule,
    CooperativesRoutingModule,
    RouterModule,
    CoreModule,
    SharedModule
  ]
})
export class CooperativesModule { }
