import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrequenciesRoutingModule } from './frequencies-routing.module';
import { FrequenciesPageComponent } from './pages/frequencies-page/frequencies-page.component';
import { ModalComponent } from './components/modal/modal.component';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  declarations: [
    FrequenciesPageComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    FrequenciesRoutingModule,
    CoreModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
    
  ]
})
export class FrequenciesModule { }
