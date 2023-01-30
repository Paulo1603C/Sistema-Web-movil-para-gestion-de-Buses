import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BusService {

  url = 'http://movilmitog-001-site1.etempurl.com/api/Bus'

  constructor(private http:HttpClient) { }

  loadBuses(): Observable<any>{
    return this.http.get(this.url)
  }

  saveBuses(cooperative:any): Observable<any>{
    return this.http.post(this.url, cooperative);
  }

  updateBuses(id:string, cooperative:any): Observable<any>{
    return this.http.put(this.url+id, cooperative);
  }

  deleteBuses(id: string): Observable<any>{
    return this.http.delete(`${this.url}/${id}`);
  }
}
