import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bus } from 'src/app/buses/model/busModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class BusService {
  url = '/api/Bus/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerBusPorId(idBus: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idBus);
  }
  listaBuss(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  guardarBus(Bus: Bus): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Bus);
  }
  eliminarBus(idBus: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idBus);
  }
}
