import { Component, OnInit } from '@angular/core';
import { Message } from '../message';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-message-form',
  templateUrl: './message-form.component.html',
  styleUrls: ['./message-form.component.css']
})
export class MessageFormComponent implements OnInit {

  constructor(private route: ActivatedRoute, private location: Location, private heroService : MessageService) { }

  ngOnInit(): void {
  }

  goBack(): void {
    this.location.back();
  }

  // save(): void {
  //   this.heroService.updateHero(this.hero)
  //     .subscribe(() => this.goBack());
  // }

}
