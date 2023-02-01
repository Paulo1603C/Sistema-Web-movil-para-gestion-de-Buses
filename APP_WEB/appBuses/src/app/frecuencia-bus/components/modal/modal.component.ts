import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Bus } from 'src/app/buses/model/busModel';
import { Frecuencia } from 'src/app/frequencies/model/frecuenciaModel';
import { BusService } from 'src/app/services/api/bus.service';
import { FrecuenciaService } from 'src/app/services/api/frecuencia.service';
import { FrecuenciaBusbusService } from 'src/app/services/api/frecuenciabus.service';
import { Frecuenciabus } from '../../model/frecuenciabusModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  idFrecuencia?: number;
  idBus?: number;
  idUsuarioH: Number = Number(localStorage.getItem('IdUsuario'));
  frecuencias?: Frecuencia[];
  buses?: Bus[];

  dataForm = new FormGroup({
    id: new FormControl(''),
    idFrecuencia: new FormControl(''),
    frecuencia: new FormControl(''),
    idBus: new FormControl(''),
    bus: new FormControl(''),
    habilitado: new FormControl(''),
    idUsuarioH: new FormControl(''),
    usuarioH: new FormControl('')
  })


  constructor(private frecuenciaService: FrecuenciaService,
    private busService: BusService,
    private frecuenciabusService: FrecuenciaBusbusService) {
  }

  id: Number = 0;
  frecuencia: string = '';
  bus: string = '';
  habilitado: boolean = true;
  usuarioH: string = '';

  borrarCampos() {
    this.dataForm.reset();
  }
  ngOnInit(): void {
    this.loadFrecuencias()
    this.loadBuses()
  }
  onSubmit() {

    var bus = new Frecuenciabus(
      this.id,
      this.idFrecuencia!,
      this.frecuencia,
      this.idBus!,
      this.bus,
      this.habilitado,
      this.idUsuarioH,
      this.usuarioH
    )
    console.log(bus);
    this.frecuenciabusService.guardarFrecuenciaBus(bus).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }

  }
  loadFrecuencias() {
    this.frecuenciaService.listaFrecuencias().subscribe(data => {
      this.frecuencias = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  loadBuses() {
    this.busService.listaBuss().subscribe(data => {
      this.buses = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
}
