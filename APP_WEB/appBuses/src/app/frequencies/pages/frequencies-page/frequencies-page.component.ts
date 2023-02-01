import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FrecuenciaService } from 'src/app/services/api/frecuencia.service';
import { Frecuencia } from '../../model/frecuenciaModel';

@Component({
  selector: 'app-frequencies-page',
  templateUrl: './frequencies-page.component.html',
  styleUrls: ['./frequencies-page.component.css']
})
export class FrequenciesPageComponent {
  sideNavStatus: boolean = false
  data: Frecuencia[] = []
  listFields: string[] = [ 'ruta',  'cooperativa', 'horaSalida', 'horaArribo', 'habilitado',  'usuarioH', 'diaSemana', 'precio']
  columns: any[] = [

    { field: 'ruta', title: 'RUTA' },
    { field: 'cooperativa', title: 'COOPERATIVA' },
    { field: 'horaSalida', title: 'HORA DE SALIDA' },
    { field: 'horaArribo', title: 'HORA DE LLEGADA' },
    { field: 'habilitado', title: 'ESTADO HABIL.' },
    { field: 'usuarioH', title: 'USUARIO HABIL.' },
    { field: 'diaSemana', title: 'DIA' },
    { field: 'precio', title: 'PRECIO' },
  ];
  constructor(private frecuenciaService: FrecuenciaService,
    private router: Router) {
  }
  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.frecuenciaService.listaFrecuencias().subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  deleteData(rowId: Number) {
    this.frecuenciaService.eliminarFrecuencia(rowId).subscribe(() => {
      this.loadData();
    });
  }

}
