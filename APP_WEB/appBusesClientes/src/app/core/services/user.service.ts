import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url = 'http://movilmitog-001-site1.etempurl.com/api/Login/Validar'

  constructor(private http:HttpClient) { }

  authentication(user:any): Observable<any>{
    return this.http.post(this.url, user);
  }
}