import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { Usuario } from '../../model/usuarioModel';

@Component({
  selector: 'app-page-usuario',
  templateUrl: './page-usuario.component.html',
  styleUrls: ['./page-usuario.component.css']
})
export class PageUsuarioComponent {
  sideNavStatus: boolean = false
  usuarioForm = new FormGroup({
    id: new FormControl(''),
    nombre: new FormControl(''),
    apellido: new FormControl(''),
    tipoIdentificacion: new FormControl(''),
    numeroIdentificacion: new FormControl(''),
    telefono: new FormControl(''),
    correo: new FormControl(''),
    direccion: new FormControl(''),
    usuario: new FormControl(''),
    password: new FormControl(''),
    idRol: new FormControl(''),
    rol: new FormControl('')
  })

  data: Usuario[] = []
  listFields: string[] = ['nombre', 'apellido', 'tipoIdentificacion', 'numeroIdentificacion', 'telefono', 'correo', 'direccion', 'usuario', 'rol']
  columns: any[] = [

    { field: 'nombre', title: 'NOMBRE' },
    { field: 'apellido', title: 'APELLIDO' },
    { field: 'tipoIdentificacion', title: 'TIPO DE IDENTIFICACION' },
    { field: 'numeroIdentificacion', title: 'NUMERO IDENTIFICACION' },
    { field: 'telefono', title: 'TELEFONO' },
    { field: 'correo', title: 'CORREO' },
    { field: 'direccion', title: 'DIRECCION' },
    { field: 'usuario', title: 'NICK' },
    { field: 'rol', title: 'ROL' }
  ];

  constructor(private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.loadData()
  }

  loadData() {
    this.usuarioService.listaUsuarios().subscribe(data => {
      this.data = data
      console.log(data)
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }

  id: number = 0
  nombre: string = ''
  representante: string = ''
  telefono: string = ''
  correo: string = ''
  paginaWeb: string = ''


  borrarCampos() {
    /*this.cooperativesForm.reset()*/
  }

  onSubmit() {
    /*  const Cooperative = {
        nombre: this.nombre,
        representante: this.representante,
        telefono: `${this.telefono}`,
        correo: this.correo,
        paginaWeb: this.paginaWeb
      }
      console.log(Cooperative)
      this.cooperativeService.saveCooperatives(Cooperative).subscribe(res => {
        console.log(res)
        this.loadCooperatives()
        this.borrarCampos()
      }), (error: any) => {
        console.log(error)
      }*/
  }

  deleteData(rowId: Number) {
    this.usuarioService.eliminarUsuario(rowId).subscribe(() => {
      this.loadData();
    });
  }
}
