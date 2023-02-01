import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { cooperative } from 'src/app/cooperatives/models/cooperative.model';
import { CooperativeService } from 'src/app/cooperatives/service/cooperative.service';
import { Ruta } from 'src/app/rutas/model/rutaModel';
import { FrecuenciaService } from 'src/app/services/api/frecuencia.service';
import { RutaService } from 'src/app/services/api/ruta.service';
import { Frecuencia } from '../../model/frecuenciaModel';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  idRuta?: number;
  idCooperativa?: number;
  idUsuarioH: Number = Number(localStorage.getItem('IdUsuario'));
  rutas?: Ruta[];
  cooperativas?: cooperative[];

  dataForm = new FormGroup({
    id: new FormControl(''),
    idRuta: new FormControl(''),
    ruta: new FormControl(''),
    idCooperativa: new FormControl(''),
    cooperativa: new FormControl(''),
    horaSalida: new FormControl(''),
    horaArribo: new FormControl(''),
    habilitado: new FormControl(''),
    idUsuarioH: new FormControl(''),
    usuarioH: new FormControl(''),
    diaSemana: new FormControl(''),
    precio: new FormControl('')
  })
  diasSemana = [
    { id: 'L', name: 'Lunes' },
    { id: 'M', name: 'Martes' },
    { id: 'W', name: 'Miercoles' },
    { id: 'J', name: 'Jueves' },
    { id: 'V', name: 'Viernes' },
    { id: 'S', name: 'Sabado' },
    { id: 'D', name: 'Domingo' },
];

  constructor(private frecuenciaService: FrecuenciaService,
    private rutaService: RutaService,
    private cooperativService: CooperativeService) {
  }

  id: Number = 0;
  ruta: string = '';
  cooperativa: string = '';
  horaSalida: string = '';
  horaArribo: string = '';
  habilitado: boolean = true;
  usuarioH: string = '';
  diaSemana: string = '';
  precio: Number = 3.5;

  borrarCampos() {
    this.dataForm.reset();
  }
  ngOnInit(): void {
    this.loadRutas()
    this.loadCooperativas()
  }
  onSubmit() {

    var bus = new Frecuencia(
      this.id,
      this.idRuta!,
      this.ruta,
      this.idCooperativa!,
      this.cooperativa,
      this.horaSalida,
      this.horaArribo,
      this.habilitado,
      this.idUsuarioH,
      this.usuarioH,
      this.diaSemana,
      this.precio,
    )
    console.log(bus);
    this.frecuenciaService.guardarFrecuencia(bus).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }

  }
  loadRutas() {
    this.rutaService.listaRutas().subscribe(data => {
      this.rutas = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  loadCooperativas() {
    this.cooperativService.loadCooperatives().subscribe(data => {
      this.cooperativas = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }

}
