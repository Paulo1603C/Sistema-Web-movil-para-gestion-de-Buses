import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TicketsService } from '../../services/tickets.service';

@Component({
  selector: 'app-buy-ticket',
  templateUrl: './buy-ticket.component.html',
  styleUrls: ['./buy-ticket.component.css']
})
export class BuyTicketComponent {
  data:any
  numAsientos:number = 0
  idViaje:number = 0;
  dataAsientos:any[] = []
  dataTickets:any[] = []
  dataCompra:any[] = []
  checkboxValue = false;
  total:number = 0;
  columns:any[] = [
    {field: 'idAsiento', title:'#'},
    {field: 'desAsiento', title: 'Descripción'},
    {field: 'categoria', title: 'Descripción'},
    {field: 'recargo', title: 'Descripción'},
  ]

  constructor(private route:ActivatedRoute, private ticketsService:TicketsService, private router: Router){
    this.route.params.subscribe( params => {
      const encodedData = params['data']
      this.data = JSON.parse(decodeURIComponent(encodedData));
      console.log(this.data)
    })
    this.llenarAsientos()
  }

  ngOnInit(){
  }

  llenarAsientos(){
    const id = this.data.idViaje
    this.ticketsService.loadTickets(id).subscribe(res => {
      this.dataTickets = res
      for (let i = 0; i <= this.dataTickets.length; i++) {
        const item = {num: res[i].idAsiento}
        this.dataAsientos.push(item)
      }
    })
  }

  capturar(event:any){
    const id = event.target.id
    const objeto = this.dataTickets.find(x => x.idAsiento == id)
    this.dataCompra.push(objeto)
    this.calculoTotal()
  }

  eliminarBoleto(id:number){
    const index = this.dataCompra.findIndex(x => x.idAsiento == id)
    this.dataCompra.splice(index)
    this.total = 0
  }

  calculoTotal(){
    for (let i = 0; i < this.dataCompra.length; i++) {
      const totalSR = 5
      const totalBoleto = totalSR + (totalSR * this.dataCompra[i].recargo)
      this.total += totalBoleto
    }
  }

  comprarBoleto(){
    this.router.navigate(['/boletos/pagos'])
  }
}
