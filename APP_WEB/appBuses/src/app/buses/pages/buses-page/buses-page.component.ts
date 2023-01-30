import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CooperativeService } from 'src/app/cooperatives/service/cooperative.service';
import { BusService } from '../../services/bus.service';

@Component({
  selector: 'app-buses-page',
  templateUrl: './buses-page.component.html',
  styleUrls: ['./buses-page.component.css']
})
export class BusesPageComponent implements OnInit {
  sideNavStatus: boolean = false
  dataBuses: any[] = []
  dataCooperatives: any[] = []
  opcionSeleccionada: string = '0'

  busesForm = new FormGroup({
    id: new FormControl(''),
    cooperativa: new FormControl(null),
    numero: new FormControl(''),
    anio: new FormControl(''),
    ramvCpn: new FormControl(''),
    modeloCar: new FormControl(''),
    marcaCh: new FormControl(''),
    transporte: new FormControl(''),
    pisos: new FormControl(''),
    capacidad: new FormControl(''),
    puertas: new FormControl(''),
    rutaImagen: new FormControl('')
  })

  listFields:string[] = ['Id','Cooperativa','Numero','Año','RamCpn','Marca Carroceria','Marcha Chasis','Transporte','Pisos','Capacidad','Puertas'] 
  columns: any[] = [
    {field: 'id', title: 'ID' },
    { field: 'cooperativa', title: 'Cooperativa' },
    {field: 'numero', title: 'Numero'},
    {field: 'anio', title: 'Año'},
    {field: 'ramvCpn', title: 'RamCpn'},
    {field: 'modeloCar', title: 'Carroceria'},
    {field: 'marcaCh', title: 'Chasis'},
    {field: 'transporte', title: 'Transporte'},
    {field: 'pisos', title: 'Pisos'},
    {field: 'capacidad', title: 'Capacidad'},
    {field: 'puertas', title: 'Puertas'},
  ];

  constructor(private busesService:BusService, private cooperativeService:CooperativeService) {
    this.loadBuses()
    this.loadCooperatives()
   }

  ngOnInit(): void {
  }

  loadCooperatives(){
    this.cooperativeService.loadCooperatives().subscribe(data => {
      this.dataCooperatives = data
      console.log(this.dataCooperatives)
    })
  }

  id = 0
  cooperativa = ''
  numero = ''
  anio = 0
  ramvCpn = ''
  modeloCar = ''
  marcaCh = ''
  transporte = ''
  pisos = 0
  capacidad = 0 
  puertas = 0
  rutaImagen = ''

  loadBuses(){
    this.busesService.loadBuses().subscribe(data => {
      this.dataBuses = data
      console.log(data)
    }), (error:any) =>{
      console.log(error)
    }
  }

  borrarCampos(){
    this.busesForm.reset()
  }

  onSubmit(){
    const idCooperative = this.getIdCooperative(this.cooperativa)
    const Buses = {
      idCooperativa: idCooperative,
      numero: this.numero,
      anio: this.anio,
      ramvCpn: this.ramvCpn,
      modeloCar: this.modeloCar,
      marcaCh: this.modeloCar,
      transporte: this.transporte,
      pisos: this.pisos,
      capacidad: this.capacidad, 
      puertas: this.puertas,
      rutaImagen: this.rutaImagen,
    }
    console.log(Buses)
    this.busesService.saveBuses(Buses).subscribe(res => {
      console.log(res)
      this.loadBuses()
      this.borrarCampos()
    }), (error: any) => {
      console.log(error)
    }
  }

  capturar(){
    this.cooperativa = this.opcionSeleccionada.toString();
  }

  getIdCooperative(cooperative:string){
    const id = this.dataCooperatives.find(x => x.nombre === cooperative)
    return id.id
  }

  deleteCooperative(rowId: string) {
    this.busesService.deleteBuses(rowId).subscribe(() => {
      this.loadBuses();
    });
  }
}
