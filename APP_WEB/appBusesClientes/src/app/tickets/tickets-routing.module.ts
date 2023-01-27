import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PurchasedTicketsComponent } from './pages/purchased-tickets/purchased-tickets.component';
import { TicketsPageComponent } from './pages/tickets-page/tickets-page.component';

const routes: Routes = [
  {path:'', component:TicketsPageComponent},
  {path:'boletos-comprados', component:PurchasedTicketsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TicketsRoutingModule { }
