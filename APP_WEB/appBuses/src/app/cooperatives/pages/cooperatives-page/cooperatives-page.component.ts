import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-cooperatives-page',
  templateUrl: './cooperatives-page.component.html',
  styleUrls: ['./cooperatives-page.component.css']
})
export class CooperativesPageComponent implements OnInit{
  sideNavStatus: boolean = false
  dataCooperatives: any[] = []
  listFields:string[] = ['#','Nombre','Representante','Teléfono','Correo','Pagina Web','Estado'] 
  columns: any[] = [
    {field: '_id', title: 'ID' },
    { field: 'nombre', title: 'Nombre' },
    {field: 'representante', title: 'Representante'},
    {field: 'telefono', title: 'Teléfono'},
    {field: 'correo', title: 'Correo'},
    {field: 'paginaweb', title: 'Pagina Web'},
    {field: 'estado', title: 'Estado'}
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
