import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environments';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root',
})
export class ServicesService {
  url = '/api/Login/Validar';
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}
  validateLogin(login: Login): Observable<any> {
    return this.http.post(this.baseUrl+this.url, login);
  }
}
