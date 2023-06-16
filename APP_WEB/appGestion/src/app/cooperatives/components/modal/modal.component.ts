import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  cooperativesForm = new FormGroup({
    id: new FormControl(''),
    nombre: new FormControl(''),
    representante: new FormControl(''),
    telefono: new FormControl(''),
    correo: new FormControl(''),
    paginaWeb: new FormControl(''),
    estado: new FormControl('')
  });

  dataCooperatives:any[] = [];
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

  constructor() { 
    this.loadClientes();
  }

  ngOnInit(): void {
  }
/*
  cliente : Cliente = {
    nombre: '',
    apellido: '',
    fechaNacimiento: '',
    telefono: '',
    correo: ''
  }
*/
  nombre:string = '';
  representante:string = '';
  telefono:string = '';
  correo:string = '';
  paginaWeb:string = '';
  estado:string = '';

  loadClientes(){
    /*.clienteService.loadClients().subscribe(data => {
      this.dataClients = data;
      console.log(this.dataClients);
    }), (error: any) => {
      console.log(error)
    }*/
  }

  borrarCampos(){
    this.cooperativesForm.reset();
  }

  deleteCliente(rowId: string) {
    /*
    this.clienteService.deleteClient(rowId).subscribe(() => {
      this.loadClientes();
    });*/
  }

  onSubmit(){
    /*
    this.clienteService.saveClient(new Cliente(this.nombre,this.apellido,
      this.fechaNacimiento,this.telefono, this.correo)).subscribe(() => {
      this.loadClientes();
      this.borrarCampos();
    }), (error: any) => {
      console.log(error)
    }*/
  }
}
