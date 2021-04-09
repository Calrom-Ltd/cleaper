import { Injectable } from '@angular/core';
import { Message } from './message';
import { MESSAGES } from './mock-data';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private allMessagesUrl = '/api/Message';
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.allMessagesUrl);
  }

  getFilteredMessages(username : string): Observable<Message[]> {
    return this.http.get<Message[]>(this.allMessagesUrl + "/" + encodeURI(username));
  }

  createUserMessage(message : Message): Observable<Message> {
    return this.http.post<Message>(this.allMessagesUrl, message, this.httpOptions);
  }
}
