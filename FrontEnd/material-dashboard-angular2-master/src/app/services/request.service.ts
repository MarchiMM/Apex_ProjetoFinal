import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Request } from '../models/Request';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  baseUrl = `${environment.apiUrl}request`;

  constructor(private http: HttpClient) { }

  getAll() : Observable<Request[]> {
    return this.http.get<Request[]>(this.baseUrl);
  }

  save(request: Request) {
    return this.http.post(this.baseUrl, request);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/id=${id}`);
  }

  edit(request: Request) {
    return this.http.put(`${this.baseUrl}/id=${request.id}`, request);
  }
}
