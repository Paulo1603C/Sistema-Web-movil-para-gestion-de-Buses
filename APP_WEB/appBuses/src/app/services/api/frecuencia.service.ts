import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Frecuencia } from 'src/app/frequencies/model/frecuenciaModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class FrecuenciaService {
  url = '/api/Frecuencia/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }
  obtenerFrecuenciaPorId(idFrecuencia: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idFrecuencia);
  }
  listaFrecuencias(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  listaFrecuenciasPorIdBus(IdBus: Number): Observable<any> {
    return this.http.get(this.baseUrl+'/PorBus/'+IdBus);
  }
  guardarFrecuencia(Frecuencia: Frecuencia): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Frecuencia);
  }
  eliminarFrecuencia(idFrecuencia: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idFrecuencia);
  }
  actualizarFrecuencia(idFrecuencia: string, Frecuencia:Frecuencia): Observable<any> {
    return this.http.put(this.baseUrl+this.url+idFrecuencia, Frecuencia);
  }
}
