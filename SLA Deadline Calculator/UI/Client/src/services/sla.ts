import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SlaService {
  private baseUrl = 'http://localhost:5000/api/sla';

  constructor(private http: HttpClient) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  create(sla: any): Observable<any> {
    return this.http.post<any>(this.baseUrl, sla);
  }
}
