import { Component, OnInit } from '@angular/core';
import { Message } from '../message';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-user-messages',
  templateUrl: './user-messages.component.html',
  styleUrls: ['./user-messages.component.css']
})

export class UserMessagesComponent implements OnInit {

  messages : Message[] = [];

  constructor(private messageService : MessageService) { }

  ngOnInit(): void {
    this.getMessages();
  }

  getMessages() : void {
    this.messageService.getMessages().subscribe(messages => this.messages = messages);
  }
}
