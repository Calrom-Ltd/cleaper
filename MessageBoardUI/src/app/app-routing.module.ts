import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserMessagesComponent } from './user-messages/user-messages.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { MessageFormComponent } from './message-form/message-form.component';

 const routes: Routes = [
  { path: '',   redirectTo: '/login', pathMatch: 'full' }, // redirect to `Login`
   { path: 'login', component: UserLoginComponent },
   { path: 'messages', component: UserMessagesComponent },
   { path: 'newMessage', component: MessageFormComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
