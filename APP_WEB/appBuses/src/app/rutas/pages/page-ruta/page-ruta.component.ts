import { Component } from '@angular/core';
import { RutaService } from 'src/app/services/api/ruta.service';
import { Ruta } from '../../model/rutaModel';

@Component({
  selector: 'app-page-ruta',
  templateUrl: './page-ruta.component.html',
  styleUrls: ['./page-ruta.component.css']
})
export class PageRutaComponent {
  sideNavStatus: boolean = false
  data: Ruta[] = []
  listFields: string[] = ['descripcion', 'lugarOrigen', 'lugarDestino']
  columns: any[] = [
    { field: 'descripcion', title: 'DESCRIPCION' },
    { field: 'lugarOrigen', title: 'LUGAR DE ORIGEN' },
    { field: 'lugarDestino', title: 'LUGAR DE DESTINO' },
  ];
  constructor(private rutaService: RutaService) {
  }

  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.rutaService.listaRutas().subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  deleteData(rowId: Number) {
    this.rutaService.eliminarRuta(rowId).subscribe(() => {
      this.loadData();
    });
  }
}
