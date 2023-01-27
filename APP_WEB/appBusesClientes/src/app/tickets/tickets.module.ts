import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TicketsRoutingModule } from './tickets-routing.module';
import { TicketsPageComponent } from './pages/tickets-page/tickets-page.component';
import { SharedModule } from '../shared/shared.module';
import { PurchasedTicketsComponent } from './pages/purchased-tickets/purchased-tickets.component';


@NgModule({
  declarations: [
    TicketsPageComponent,
    PurchasedTicketsComponent
  ],
  imports: [
    CommonModule,
    TicketsRoutingModule,
    SharedModule
  ],
  exports: [
    PurchasedTicketsComponent
  ]
})
export class TicketsModule { }
