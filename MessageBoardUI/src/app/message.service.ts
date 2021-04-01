import { Injectable } from '@angular/core';
import { Message } from './message';
import { MESSAGES } from './mock-data';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private messageUrl = '/api/Message';

  constructor(private http: HttpClient) { }

  // getMessages(): Observable<Message[]> {
  //   const messages = of(MESSAGES)
  //   return messages;
  // }

  getMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.messageUrl)
  }
}
