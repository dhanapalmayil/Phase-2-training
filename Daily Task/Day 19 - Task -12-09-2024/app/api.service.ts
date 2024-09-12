import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Organization } from './org-details/Organization';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiurl="https://localhost:7076/api/Organizations1"

  constructor(private http:HttpClient) { }
  get():Observable<any>
  {
    return this.http.get(this.apiurl);
  }
  getbyid(id:number):Observable<any>
  {
    return this.http.get(`${this.apiurl}/${id}`)
  }
  postcomp(Org:Organization):Observable<any>
  {
    return this.http.post<any>(`${this.apiurl}`,Org)
  }
  delete(id:number):Observable<any>
  {
    return this.http.delete(`${this.apiurl}/${id}`)
  }
  update(id:number,Org:Organization):Observable<any>
  {
    return this.http.put(`${this.apiurl}/${id}`,Org);
   }
}
