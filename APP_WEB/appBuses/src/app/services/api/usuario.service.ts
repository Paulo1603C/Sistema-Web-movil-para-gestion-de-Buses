import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/usuarios/model/usuarioModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  url = '/api/Usuario/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerUsuarioPorId(idUsuario: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idUsuario);
  }
  listaUsuarios(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  guardarUsuario(usuario: Usuario): Observable<any> {
    return this.http.post(this.baseUrl+this.url,usuario);
  }
  eliminarUsuario(idUsuario: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idUsuario);
  }
  actualizarUsuario(idUsuario: string,usuario: Usuario): Observable<any> {
    return this.http.put(this.baseUrl+this.url+idUsuario,usuario);
  }
}
