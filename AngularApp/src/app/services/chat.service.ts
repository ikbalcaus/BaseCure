import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../server-settings';
import { AuthService } from './auth.service';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class ChatService {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) { this.startConnection() }

  private hubConnection: HubConnection | undefined;
  messageReceived = new Subject<{ senderId: number, message: string, dateTime: string }>();

  private startConnection() {
    this.hubConnection = this.buildHubConnection();
    this.hubConnection.start()
      .then(() => this.updateConnectionId())
  }

  private buildHubConnection() {
    return new HubConnectionBuilder()
      .withUrl(serverSettings.address + "/chatHub")
      .configureLogging(LogLevel.Information)
      .build();
  }

  private updateConnectionId() {
    const userId = this.authService.getAuthToken().korisnikId;
    const connectionId = this.hubConnection?.connectionId;
    this.httpClient.patch(serverSettings.address + "/korisnici/" + userId, { konekcijskiId: connectionId }).subscribe();
  }

  addListeners() {
    if(this.hubConnection) {
      this.hubConnection.on("ReceiveMessage", (senderId: number, message: string, dateTime: string) => {
        this.messageReceived.next({ senderId, message, dateTime });
      });
    }
  }

  sendMessageToUser(receiverId: number, message: string) {
    const senderId = this.authService.getAuthToken().korisnikId;
    if(this.hubConnection && receiverId) {
      this.hubConnection.invoke("SendMessageToUser", senderId, receiverId, message)
    }
  }

  getMessageObservable() {
    return this.messageReceived.asObservable();
  }

  removeConnectionId() {
    const userId = this.authService.getAuthToken().korisnikId;
    this.httpClient.patch(serverSettings.address + "/korisnici/" + userId, { konekcijskiId: null }).subscribe();
  }
}
