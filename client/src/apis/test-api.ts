import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarpoolEntry } from './generated/model/carpoolEntry';

@Injectable({
  providedIn: 'root'
})

// This API class just connects the client with the server via REST calls.
// Use only for testing purposes.
export class TestApi {

  constructor(public http: HttpClient) { }

  private domain = 'http://localhost:5037/api/';
  private serverUrl = this.domain + 'CarpoolEntry';

  public getCarpoolEntries() {
    return this.http.get<any>(this.serverUrl);
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
