import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { Usuario } from '../../model/usuarioModel';
import { ElementRef, ViewChild } from '@angular/core';
import { Categoria } from '../../model/categoria.Model';
import { CategoriaService } from 'src/app/services/api/categoria.service';
import { Rol } from '../../model/rolModel';
import { RolService } from 'src/app/services/api/rol.service';

@Component({
  selector: 'app-page-usuario',
  templateUrl: './page-usuario.component.html',
  styleUrls: ['./page-usuario.component.css']
})
export class PageUsuarioComponent {
  @ViewChild('content') element: ElementRef | undefined;
  form_id = new FormControl('');
  form_nombre = new FormControl('');
  form_apellido = new FormControl('');
  form_tipoIdentificacion = new FormControl('');
  form_numeroIdentificacion = new FormControl('');
  form_telefono = new FormControl('');
  form_correo = new FormControl('');
  form_direccion = new FormControl('');
  form_usuario = new FormControl('');
  form_password = new FormControl('');
  form_idRol = new FormControl('');
  tipoDoc = [
    { id: 'C', name: 'Cédula' },
    { id: 'R', name: 'Ruc' },
    { id: 'P', name: 'Pasaporte' },
  ];

  sideNavStatus: boolean = false

  data: Usuario[] = []
  roles: Rol[] = []
  row!: Usuario;
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

  constructor(private usuarioService: UsuarioService,
    config: NgbModalConfig, private modalService: NgbModal,
    private rolService: RolService) {
    config.backdrop = 'static';
    config.keyboard = false;
  }
  open(content: any) {
    this.modalService.open(content);
  }

  ngOnInit(): void {
    this.loadData()
    this.loadRoles()
  }

  loadData() {
    this.usuarioService.listaUsuarios().subscribe(data => {
      this.data = data
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
    this.row.nombre = this.form_nombre.getRawValue()!;
    this.row.apellido = this.form_apellido.getRawValue()!;
    this.row.tipoIdentificacion = this.form_tipoIdentificacion.getRawValue()!;
    this.row.numeroIdentificacion = this.form_numeroIdentificacion.getRawValue()!;
    this.row.telefono = this.form_telefono.getRawValue()!;
    this.row.correo = this.form_correo.getRawValue()!;
    this.row.direccion = this.form_direccion.getRawValue()!;
    this.row.usuario = this.form_usuario.getRawValue()!;
    this.row.password = this.form_password.getRawValue()!;
    this.row.idRol = Number(this.form_idRol.getRawValue());

    this.usuarioService.actualizarUsuario(this.row.id.toString(), this.row).subscribe(() => {
      this.borrarCampos();
      window.location.reload();
    }), (error: any) => {
      console.log(error)
    }

  }

  deleteData(rowId: Number) {
    this.usuarioService.eliminarUsuario(rowId).subscribe(() => {
      this.loadData();
    });
  }
  abrir(id: Number) {
    this.loadRow(id);

    this.modalService.open(this.element)
  }
  cargarRowFormulario() {
    this.form_id.setValue(this.row.id.toString());
    this.form_nombre.setValue(this.row.nombre);
    this.form_apellido.setValue(this.row.apellido);
    this.form_tipoIdentificacion.setValue(this.row.tipoIdentificacion);
    this.form_numeroIdentificacion.setValue(this.row.numeroIdentificacion);
    this.form_telefono.setValue(this.row.telefono);
    this.form_correo.setValue(this.row.correo);
    this.form_direccion.setValue(this.row.direccion);
    this.form_usuario.setValue(this.row.usuario);
    this.form_password.setValue(this.row.password);
    this.form_idRol.setValue(this.row.idRol.toString());
  }
  loadRow(id: Number) {
    this.usuarioService.obtenerUsuarioPorId(id.toString()).subscribe(data => {
      this.row = data;
      this.cargarRowFormulario();
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  loadRoles() {
    this.rolService.listaRols().subscribe(data => {
      this.roles = data;
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
}
