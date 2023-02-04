import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { Usuario } from '../../model/usuarioModel';


@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})

export class ModalComponent {

  selectedRol?: number;
  selectedTd?:string;
  roles: any[]=[];    
  roles1 = [
        { id: 1, name: 'Administrador - Cooperativa' },
        { id: 4, name: 'Oficinista - Cooperativa' },
        { id: 5, name: 'Cliente' },
    ];
    roles3 = [
      { id: 1, name: 'Administrador - Cooperativa' },
      { id: 2, name: 'Aprobador - ANT' },
      { id: 3, name: 'Administrador - ANT' }
  ];
  roles6 = [
    { id: 1, name: 'Administrador - Cooperativa' },
    { id: 2, name: 'Aprobador - ANT' },
    { id: 3, name: 'Administrador - ANT' },
    { id: 4, name: 'Oficinista - Cooperativa' },
    { id: 5, name: 'Cliente' },
];
    tipoDoc= [
      { id: 'C', name: 'Cédula'},
      { id: 'R', name: 'Ruc' },
      { id: 'P', name: 'Pasaporte' },
  ];

  asignarRolesPermitidos(){
    let IdRol=localStorage.getItem('IdRol');
    switch (IdRol) {
      case '1':
        this.roles=this.roles1;
        break;
        case '3':
          this.roles=this.roles3;
        break;
        case '6':
          this.roles=this.roles6;
        break;
      default:
        break;
    }
  }
  usuarioForm = new FormGroup({
    id: new FormControl(''),
    nombre: new FormControl(''),
    apellido: new FormControl(''),
    selectedTd: new FormControl(''),
    numeroIdentificacion: new FormControl(''),
    telefono: new FormControl(''),
    correo: new FormControl(''),
    direccion: new FormControl(''),
    usuario: new FormControl(''),
    password: new FormControl(''),
    selectedRol: new FormControl(''),
    rol: new FormControl('')
      })

  constructor(private ususarioService: UsuarioService, private router: Router) { 
    this.asignarRolesPermitidos();
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
id: Number=0
nombre: string=''
apellido: string=''
tipoIdentificacion: string=''
numeroIdentificacion: string=''
telefono: string=''
correo: string=''
direccion: string=''
usuario: string=''
password: string=''
rol: string=''

  loadClientes(){
   /* .clienteService.loadClients().subscribe(data => {
      this.dataClients = data;
      console.log(this.dataClients);
    }), (error: any) => {
      console.log(error)
    }*/
  }

  borrarCampos(){
    this.usuarioForm.reset();
  }

  

  onSubmit(){

    var usuario=new Usuario(this.id,
      this.nombre,
      this.apellido,
      this.selectedTd!,
      this.numeroIdentificacion,
      this.telefono,
      this.correo,
      this.direccion,
      this.usuario,
      this.password,
      this.selectedRol!,
      this.rol)
      console.log(usuario);
    this.ususarioService.guardarUsuario(usuario).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }
    
  }
}
