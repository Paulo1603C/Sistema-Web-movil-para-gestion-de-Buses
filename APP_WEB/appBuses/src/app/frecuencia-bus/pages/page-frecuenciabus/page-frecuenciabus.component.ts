import { Component } from '@angular/core';
import { FrecuenciaBusbusService } from 'src/app/services/api/frecuenciabus.service';
import { Frecuenciabus } from '../../model/frecuenciabusModel';

@Component({
  selector: 'app-page-frecuenciabus',
  templateUrl: './page-frecuenciabus.component.html',
  styleUrls: ['./page-frecuenciabus.component.css']
})
export class PageFrecuenciabusComponent {
  sideNavStatus: boolean = false
  data: Frecuenciabus[] = []
  listFields: string[] = ['frecuencia','bus','usuarioH']
  columns: any[] = [
    { field: 'frecuencia', title: 'Frecuencia' },
    { field: 'bus', title: 'Bus' },
    { field: 'usuarioH', title: 'Usuario Responsable' },
  ];
  constructor(private frecuenciabusService: FrecuenciaBusbusService) {
  }

  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.frecuenciabusService.listaFrecuenciaBuss().subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  deleteData(rowId: Number) {
    this.frecuenciabusService.eliminarFrecuenciaBus(rowId).subscribe(() => {
      this.loadData();
    });
  }
}
