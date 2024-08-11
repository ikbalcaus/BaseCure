import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { ChatService } from '../../../services/chat.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [CommonModule, FormsModule, TranslateModule],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {
  constructor(
    public route: ActivatedRoute,
    public chatService: ChatService
  ) {}

  message: string = "";
  messages: any[] = [];
  private messageSubscription: Subscription | undefined;

  ngOnInit() {
    this.chatService.addListeners();
    this.messageSubscription = this.chatService.getMessageObservable().subscribe(({ senderId, message }) => {
      if(senderId == Number(this.route.snapshot.paramMap.get("id"))) {
        this.messages.push({ message, sender: "other" });
      }
    });
  }

  sendMessageToUser(message: string) {
    if(message) {
      this.message = "";
      this.messages.push({ message: message, sender: "me" });
      this.chatService.sendMessageToUser(Number(this.route.snapshot.paramMap.get("id")), message);
    }
  }

  ngOnDestroy() {
    if (this.messageSubscription) {
      this.messageSubscription.unsubscribe();
    }
  }
}
