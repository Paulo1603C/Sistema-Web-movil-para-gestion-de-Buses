import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lugar } from 'src/app/rutas/model/lugarModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class LugarService {
  url = '/api/Lugar/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerLugarPorId(idLugar: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idLugar);
  }
  listaLugars(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  guardarLugar(Lugar: Lugar): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Lugar);
  }
  eliminarLugar(idLugar: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idLugar);
  }
}
