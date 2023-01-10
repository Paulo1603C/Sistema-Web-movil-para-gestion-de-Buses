import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  frequenciesForm = new FormGroup({
    id: new FormControl(''),
    ruta: new FormControl(''),
    cooperativa: new FormControl(''),
    hora_salida: new FormControl(''),
    hora_arribo: new FormControl(''),
    usuario: new FormControl(''),
    dis_semana: new FormControl('')
  });

  dataFrequencies:any[] = [];
  listFields:string[] = ['#','Ruta','Cooperativa','Hora de salida','Hora de arribo','Dia de la semana'] 
  columns: any[] = [
    {field: '_id', title: 'ID' },
    { field: 'ruta', title: 'Ruta' },
    { field: 'cooperativa', title: 'Cooperativa' },
    {field: 'hora_salida', title: 'Hora de salida'},
    {field: 'hora_arribo', title: 'Hora de arribo'},
    {field: 'dia_semana', title: 'Dia de la semana'}
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
ruta: string = ''
cooperativa: string = ''
hora_salida: string = ''
hora_arribo: string = ''
usuario: string = ''
dia_semana: string = ''

  loadClientes(){
    /*.clienteService.loadClients().subscribe(data => {
      this.dataClients = data;
      console.log(this.dataClients);
    }), (error: any) => {
      console.log(error)
    }*/
  }

  borrarCampos(){
    this.frequenciesForm.reset();
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
