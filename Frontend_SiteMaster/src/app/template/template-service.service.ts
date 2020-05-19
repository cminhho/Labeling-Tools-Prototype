import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';

type EntityResponseType = HttpResponse<any>;

@Injectable({
  providedIn: 'root',
})
export class TemplateServiceService {
  public resourceUrl = 'api/assets';

  constructor(private http: HttpClient) {}

  query(req?: any): Observable<EntityResponseType> {
    return this.http.get<any[]>(this.resourceUrl, { params: {}, observe: 'response' });
  }
}
