import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbNavLink } from '@ng-bootstrap/ng-bootstrap';
import { BusService } from 'src/app/services/api/bus.service';
import { Bus } from '../../model/busModel';

@Component({
  selector: 'app-buses-page',
  templateUrl: './buses-page.component.html',
  styleUrls: ['./buses-page.component.css']
})
export class BusesPageComponent implements OnInit {
  sideNavStatus: boolean = false
  data: Bus[] = []
  listFields: string[] = ['cooperativa','numero','anio','ramvCpn','modeloCar','marcaCh','transporte','pisos','capacidad','puertas','rutaImagen']
  
  columns: any[] = [
    { field: 'cooperativa', title: 'COOPERATIVA' },
    { field: 'numero', title: 'NUMERO' },
    { field: 'anio', title: 'AÑO' },
    { field: 'ramvCpn', title: 'RAMV /CPN/ PLACA' },
    { field: 'modeloCar', title: 'MODELO CARROCERIA' },
    { field: 'marcaCh', title: ' MARCA CHASIS' },
    { field: 'transporte', title: 'TRANSPORTE' },
    { field: 'pisos', title: 'PISOS' },
    { field: 'capacidad', title: 'CAPACIDAD ASIENTOS' },
    { field: 'puertas', title: 'PUERTAS' },
     ];
  constructor(private busService: BusService,
    private router: Router) {
  }
  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.busService.listaBuss().subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  deleteData(rowId: Number) {
    this.busService.eliminarBus(rowId).subscribe(() => {
      this.loadData();
    });
  }
  abrir(IdBus: Number) {
    this.router.navigate(['/asientos/'+IdBus])
  }
}
