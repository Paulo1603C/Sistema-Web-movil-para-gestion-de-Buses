import { Component } from '@angular/core';

@Component({
  selector: 'app-page-usuario',
  templateUrl: './page-usuario.component.html',
  styleUrls: ['./page-usuario.component.css']
})
export class PageUsuarioComponent {
  sideNavStatus: boolean = false
  dataBuses: any[] = []
  listFields:string[] = ['#','Cooperativa','Numero','Año','Modelo','Capacidad'] 
  columns: any[] = [
    {field: '_id', title: 'ID' },
    { field: 'cooperativa', title: 'Cooperativa' },
    {field: 'numero', title: 'Numero'},
    {field: 'año', title: 'Año'},
    {field: 'modelo', title: 'Modelo'},
    {field: 'capacidad', title: 'Capacidad'},
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
