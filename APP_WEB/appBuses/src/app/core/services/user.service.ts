import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url = 'http://movilmitog-001-site1.etempurl.com/api/Login/Validar'
 
  constructor(private http:HttpClient) { }

  authentication(user:User): Observable<any>{
    return this.http.post(this.url, user);
  }
}
