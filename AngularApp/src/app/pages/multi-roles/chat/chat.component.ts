import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { ChatService } from '../../../services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { AuthService } from '../../../services/auth.service';
import { ModalComponent } from '../../../components/modal/modal.component';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent, TranslateModule],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private chatService: ChatService
  ) {}

  private messageSubscription: Subscription | undefined;
  messageId: number = 0;
  message: string = "";
  senderId: number = this.authService.getAuthToken().korisnikId;
  receiverId: number = Number(this.route.snapshot.paramMap.get("id"));
  receiverName: string = "";
  oldMessages: any[] = [];
  newMessages: any[] = [];

  ngOnInit() {
    this.httpClient.get<any>(serverSettings.address + "/korisnici/" + this.receiverId).subscribe(
      res => {
        if(res.ime == null) this.receiverName = res.prezime;
        else if(res.prezime == null) this.receiverName = res.ime;
        else this.receiverName = res.ime + " " + res.prezime;
        if(!((
          this.authService.getAuthToken().uloga == "ljekar" && res.uloga == "ljekar" ||
          this.authService.getAuthToken().uloga == "ljekar" && res.uloga == "korisnik" ||
          this.authService.getAuthToken().uloga == "korisnik" && res.uloga == "ljekar") &&
          this.receiverId != this.senderId
        )) {
          this.router.navigateByUrl("/");
        }
      }
    );

    this.httpClient.patch(serverSettings.address + "/poruke?korisnikId1=" + this.senderId + "&korisnikId2=" + this.receiverId, null).subscribe();
    this.httpClient.get<any>(serverSettings.address + "/poruke?korisnikId1=" + this.senderId + "&korisnikId2=" + this.receiverId).subscribe(
      res => this.oldMessages = res
    );
    this.chatService.addListeners();
    this.messageSubscription = this.chatService.getMessageObservable().subscribe(({ senderId, message, dateTime }) => {
      if(senderId == this.receiverId) {
        this.newMessages.push({ sender: "other", message: message, dateTime: dateTime });
        this.httpClient.patch(serverSettings.address + "/poruke?korisnikId1=" + this.senderId + "&korisnikId2=" + this.receiverId, null).subscribe();
      }
    });
  }

  ngAfterViewChecked() {
    const container = (document.getElementById("messages-container")) as HTMLElement;
    container.scrollTop = container.scrollHeight;
  }

  formatDateTime(dateTime: string) {
    return dateTime.substring(8, 10) + "." + dateTime.substring(5, 7) + "." + dateTime.substring(0, 4) + "  " + dateTime.substring(11, 16);
  }

  sendMessageToUser(message: string) {
    if(message) {
      this.message = "";
      this.newMessages.push({ sender: "me", message: message, dateTime: new Date().toISOString() });
      this.chatService.sendMessageToUser(this.receiverId, message);
    }
  }

  ngOnDestroy() {
    if(this.messageSubscription) {
      this.messageSubscription.unsubscribe();
    }
    this.chatService.removeConnectionId();
  }

  deleteMessage() {
    this.oldMessages = this.oldMessages.filter(i => i.porukaId != this.messageId);
    this.httpClient.delete(serverSettings.address + "/poruke/" + this.messageId + "?korisnikId1=" + this.senderId + "&korisnikId2=" + this.receiverId).subscribe();
  }
}
