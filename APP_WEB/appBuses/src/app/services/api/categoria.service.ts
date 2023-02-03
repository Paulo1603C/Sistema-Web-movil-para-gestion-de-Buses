import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/usuarios/model/categoria.Model';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  url = '/api/Categoria/';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  obtenerCategoriaPorId(idCategoria: string): Observable<any> {
    return this.http.get(this.baseUrl+this.url+idCategoria);
  }
  listaCategorias(): Observable<any> {
    return this.http.get(this.baseUrl+this.url);
  }
  guardarCategoria(Categoria: Categoria): Observable<any> {
    return this.http.post(this.baseUrl+this.url,Categoria);
  }
  eliminarCategoria(idCategoria: Number): Observable<any> {
    return this.http.delete(this.baseUrl+this.url+idCategoria);
  }
}
