import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { cooperative } from '../models/cooperative.model';

@Injectable({
  providedIn: 'root'
})
export class CooperativeService {

  url = 'http://movilmitog-001-site1.etempurl.com/api/Cooperativa'

  constructor(private http:HttpClient) { }

  loadCooperatives(): Observable<any>{
    return this.http.get(this.url)
  }

  saveCooperatives(cooperative:cooperative): Observable<any>{
    return this.http.post(this.url, cooperative);
  }

  updateCooperatives(id:string, cooperative:cooperative): Observable<any>{
    return this.http.put(this.url+id, cooperative);
  }

  deleteCooperatives(id: string): Observable<any>{
    return this.http.delete(`${this.url}/${id}`);
  }
}
