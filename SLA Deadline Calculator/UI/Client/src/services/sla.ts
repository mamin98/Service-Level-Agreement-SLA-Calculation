import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SlaService {
  private baseUrl = 'http://localhost:5000/api/sla';

  constructor(private http: HttpClient) { }

  calculateDeadline(request: any): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/calculate-deadline`, {
      params: {
        priority: request.priority,
        captureDateTime: request.captureDateTime
      }
    });
  }
}
