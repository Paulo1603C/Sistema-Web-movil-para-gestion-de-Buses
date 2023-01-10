import { Component } from '@angular/core';

@Component({
  selector: 'app-frequencies-page',
  templateUrl: './frequencies-page.component.html',
  styleUrls: ['./frequencies-page.component.css']
})
export class FrequenciesPageComponent {
  sideNavStatus: boolean = false
  dataFrequencies: any[] = []
  listFields:string[] = ['#','Ruta','Cooperativa','Hora de salida','Hora de arribo','Dia de la semana'] 
  columns: any[] = [
    {field: '_id', title: 'ID' },
    { field: 'ruta', title: 'Ruta' },
    { field: 'cooperativa', title: 'Cooperativa' },
    {field: 'hora_salida', title: 'Hora de salida'},
    {field: 'hora_arribo', title: 'Hora de arribo'},
    {field: 'dia_semana', title: 'Dia de la semana'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

  deleteCooperative(rowId: string) {
    /*
    this.clienteService.deleteClient(rowId).subscribe(() => {
      this.loadClientes();
    });
    */
  }
}
