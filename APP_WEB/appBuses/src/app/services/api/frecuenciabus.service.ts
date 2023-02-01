import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Frecuenciabus } from 'src/app/frecuencia-bus/model/frecuenciabusModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class FrecuenciaBusbusService {
  url = '/api/FrecuenciaBus/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }
  obtenerFrecuenciaBusPorId(idFrecuenciaBus: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idFrecuenciaBus);
  }
  listaFrecuenciaBuss(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  listaFrecuenciaBussPorIdBus(IdBus: Number): Observable<any> {
    return this.http.get(this.baseUrl+'/PorBus/'+IdBus);
  }
  guardarFrecuenciaBus(FrecuenciaBus: Frecuenciabus): Observable<any> {
    return this.http.post(this.baseUrl+this.url,FrecuenciaBus);
  }
  eliminarFrecuenciaBus(idFrecuenciaBus: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idFrecuenciaBus);
  }
  actualizarFrecuenciaBus(idFrecuenciaBus: string, FrecuenciaBus:Frecuenciabus): Observable<any> {
    return this.http.put(this.baseUrl+this.url+idFrecuenciaBus, FrecuenciaBus);
  }
}
