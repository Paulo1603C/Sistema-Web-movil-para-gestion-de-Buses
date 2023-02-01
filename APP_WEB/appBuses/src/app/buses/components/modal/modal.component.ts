import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { cooperative } from 'src/app/cooperatives/models/cooperative.model';
import { CooperativeService } from 'src/app/cooperatives/service/cooperative.service';
import { BusService } from 'src/app/services/api/bus.service';
import { Bus } from '../../model/busModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  selectedCo?: number;
  cooperativas?: cooperative[];

  busForm = new FormGroup({
    id: new FormControl(''),
    selectedCo: new FormControl(''),
    cooperativa: new FormControl(''),
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

  constructor(private busService: BusService,
    private cooperativaService: CooperativeService) {
  }

  id: Number = 0;
  idCooperativa: Number = 0;
  cooperativa: string = '';
  numero: string = '';
  anio: Number = 0;
  ramvCpn: string = '';
  modeloCar: string = '';
  marcaCh: string = '';
  transporte: string = '';
  pisos: Number = 0;
  capacidad: Number = 0;
  puertas: Number = 0;
  rutaImagen: string = '';

  borrarCampos() {
    this.busForm.reset();
  }
  ngOnInit(): void {
    this.loadData()
  }
  onSubmit() {
    console.log(this.selectedCo);
    var bus = new Bus(
      this.id,
      this.selectedCo!,
      this.cooperativa,
      this.numero,
      this.anio,
      this.ramvCpn,
      this.modeloCar,
      this.marcaCh,
      this.transporte,
      this.pisos,
      this.capacidad,
      this.puertas,
      this.rutaImagen
    )
    console.log(bus);
    this.busService.guardarBus(bus).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }

  }
  loadData(){
    this.cooperativaService.loadCooperatives().subscribe(data => {
      this.cooperativas = data
      console.log(data)
    }), (error:any) => {
      console.log('se imprime error'+error)
    }
  }


}
