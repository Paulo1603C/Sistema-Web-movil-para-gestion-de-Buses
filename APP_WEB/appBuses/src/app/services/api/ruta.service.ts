import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ruta } from 'src/app/rutas/model/rutaModel';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class RutaService {
  url = '/api/Ruta/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerRutaPorId(idRuta: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idRuta);
  }
  listaRutas(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  guardarRuta(Ruta: Ruta): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Ruta);
  }
  eliminarRuta(idRuta: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idRuta);
  }
}
