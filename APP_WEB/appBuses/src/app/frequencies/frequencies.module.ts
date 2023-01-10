import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrequenciesRoutingModule } from './frequencies-routing.module';
import { FrequenciesPageComponent } from './pages/frequencies-page/frequencies-page.component';
import { ModalComponent } from './components/modal/modal.component';


@NgModule({
  declarations: [
    FrequenciesPageComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    FrequenciesRoutingModule
  ]
})
export class FrequenciesModule { }
