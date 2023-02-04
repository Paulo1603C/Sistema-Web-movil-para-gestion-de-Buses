import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { Usuario } from 'src/app/usuarios/model/usuarioModel';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  @Output() sideNavToggle = new EventEmitter<boolean>();
  menuStatus: boolean = false
  IdUsuario:string=localStorage.getItem('IdUsuario')!;
  usuario?:Usuario;
  constructor(private usuarioService:UsuarioService, private router:Router) { }

  ngOnInit(): void {
    this.leerUsuario();
  }

  
  SideNavToggle(){
    this.menuStatus = !this.menuStatus
    this.sideNavToggle.emit(this.menuStatus)
  }
  leerUsuario(){
    this.usuarioService.obtenerUsuarioPorId(this.IdUsuario).subscribe(data => {
      this.usuario = data;
    }), (error: any) => {
      console.log('se imprime error' + error)
    }
  }
  cerrarSesion(){
    localStorage.removeItem('IdUsuario');
    localStorage.removeItem('IdRol');
    localStorage.removeItem('token');
    this.router.navigate(['']);


  }
}
