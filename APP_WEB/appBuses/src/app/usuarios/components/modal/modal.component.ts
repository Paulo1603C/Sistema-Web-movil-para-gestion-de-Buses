import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  busesForm = new FormGroup({
    id: new FormControl(''),
    cooperativa: new FormControl(''),
    numero: new FormControl(''),
    anio: new FormControl(''),
    ramvCpn: new FormControl(''),
    modelo: new FormControl(''),
    marcaChasis: new FormControl(''),
    transporte: new FormControl(''),
    pisos: new FormControl(''),
    capacidad: new FormControl(''),
    puertas: new FormControl(''),
    imagen: new FormControl(''),
  });

  dataCooperatives:any[] = [];
  listFields:string[] = ['#','Nombre','Representante','Teléfono','Correo','Pagina Web','Estado'] 
  columns: any[] = [
    {field: '_id', title: 'ID' },
    {field: 'nombre', title: 'Nombre' },
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
id: string = ''
cooperativa: string = ''
numero: string = ''
anio: string = ''
ramvCpn: string = ''
modelo: string = ''
marcaChasis: string = ''
transporte: string = ''
pisos: string = ''
capacidad: string = ''
puertas: string = ''
imagen: string = ''

  loadClientes(){
    /*.clienteService.loadClients().subscribe(data => {
      this.dataClients = data;
      console.log(this.dataClients);
    }), (error: any) => {
      console.log(error)
    }*/
  }

  borrarCampos(){
    this.busesForm.reset();
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
