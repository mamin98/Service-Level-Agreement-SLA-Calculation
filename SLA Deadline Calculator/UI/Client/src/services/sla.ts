import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SlaService {
  private apiUrl = 'https://localhost:5000/api/sla';

  constructor(private http: HttpClient) {}

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  create(sla: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, sla);
  }
}
