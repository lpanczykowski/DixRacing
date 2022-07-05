import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DropdownValue } from 'app/_models/dropdown';
import { environment } from 'environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  get(endpoint: string, params?:HttpParams) {

    return this.http.get<DropdownValue[]>(this.baseUrl + 'dropdown/' + endpoint, {
      params: params,
    });
  }

}
