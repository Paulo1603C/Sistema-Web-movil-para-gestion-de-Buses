import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Asiento } from 'src/app/asientos/model/asientoModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class AsientoService {
  url = '/api/Asiento/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerAsientoPorId(idAsiento: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idAsiento);
  }
  listaAsientos(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  listaAsientosPorIdBus(IdBus: Number): Observable<any> {
    return this.http.get(this.baseUrl+'/PorBus/'+IdBus);
  }
  guardarAsiento(Asiento: Asiento): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Asiento);
  }
  eliminarAsiento(idAsiento: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idAsiento);
  }
  actualizarAsiento(idAsiento: string, asiento:Asiento): Observable<any> {
    return this.http.put(this.baseUrl+this.url+idAsiento, asiento);
  }

}
