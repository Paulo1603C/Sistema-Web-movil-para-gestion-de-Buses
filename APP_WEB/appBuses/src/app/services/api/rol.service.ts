import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rol } from 'src/app/usuarios/model/rolModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class RolService {
  url = '/api/Rol/';
  baseUrl = environment.baseUrl;
  token= localStorage.getItem('token');
  constructor(private http: HttpClient) { }

  obtenerRolPorId(idRol: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idRol);
  }
  listaRols(): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}`,
    });
    const requestOption = {headers:headers};
    return this.http.get(this.baseUrl+this.url, requestOption );
  }
  guardarRol(Rol: Rol): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Rol);
  }
  eliminarRol(idRol: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idRol);
  }
}
