import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from './login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private messageUrl = '/api/Login';
  
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<boolean>(this.messageUrl, {username, password}, this.httpOptions);
  }
}
