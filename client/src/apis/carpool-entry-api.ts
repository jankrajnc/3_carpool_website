import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarpoolEntry } from '../models/carpool-entry';

@Injectable({
  providedIn: 'root'
})

// This API class just connects the client with the server via REST calls.
export class CarpoolEntryApi {

  constructor(public http: HttpClient) { }

  // https://www.kevinboosten.dev/how-i-use-an-openapi-spec-in-my-angular-projects poglej se druge toole
  // new link: http://localhost:5037/swagger/v1/swagger.json must be full link

  private domain = 'http://localhost:5037/';
  private serverUrl = this.domain + 'cars';

  public getCarpoolEntries() {
    return this.http.get<CarpoolEntry[]>(this.serverUrl);
  }

  public getCarpoolEntry(id: number) {
    const url = `${this.serverUrl}/${id}`;
    return this.http.get<CarpoolEntry[]>(url);
  }

  public createCarpoolEntry(data: CarpoolEntry) {
    return this.http.post<CarpoolEntry>(this.serverUrl, data);
  }

  public updateCarpoolEntry(id: number, data: CarpoolEntry) {
    const url = `${this.serverUrl}/${id}`;
    return this.http.put<CarpoolEntry>(url, data);
  }

  public deleteCarpoolEntry(id: number) {
    const url = `${this.serverUrl}/${id}`;
    return this.http.delete<any>(url);
  }

}
