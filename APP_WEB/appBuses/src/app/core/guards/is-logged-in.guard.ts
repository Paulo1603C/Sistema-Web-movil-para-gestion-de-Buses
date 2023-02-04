import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { Usuario } from 'src/app/usuarios/model/usuarioModel';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class IsLoggedInGuard implements CanActivate {
  respuesta: boolean = false;
  IdRol:string=localStorage.getItem('IdRol')!;
  constructor(private usuarioService: UsuarioService, private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.validarRol(route);
  }


  validarRol(route: ActivatedRouteSnapshot) {
    let numeroCoincidencias:number=0;
    route.data['roles'].forEach((element: string) => {
      if (element == this.IdRol) {
        numeroCoincidencias = numeroCoincidencias + 1;
    }
    });
  
      if (numeroCoincidencias > 0) {
        console.log('Rol Autorizado');
        
        return true;
      } else {
        console.log('Rol No Autorizado');
        this.router.navigate(['inicio']);
        return this.respuesta;
      }

  }

 

}
