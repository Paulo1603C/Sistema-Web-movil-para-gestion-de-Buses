import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InfoTicketsComponent } from './pages/info-tickets/info-tickets.component';
import { PurchasedTicketsComponent } from './pages/purchased-tickets/purchased-tickets.component';
import { TicketsPageComponent } from './pages/tickets-page/tickets-page.component';

const routes: Routes = [
  {path:'', component:TicketsPageComponent},
  {path:'boletos-comprados', component:PurchasedTicketsComponent},
  {path:'info', component:InfoTicketsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketsRoutingModule { }
