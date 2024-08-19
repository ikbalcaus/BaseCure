import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { AuthService } from '../../../services/auth.service';
import { serverSettings } from '../../../server-settings';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-manage-messages',
  standalone: true,
  imports: [CommonModule, TranslateModule, RouterModule],
  templateUrl: './manage-messages.component.html',
  styleUrl: './manage-messages.component.css'
})
export class ManageMessagesComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {}

  res: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/poruke/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.res = res
    );
  }

  countMessages(status: string) {
    return this.res.filter((x: any) => (status == 'neprocitana') ? x.neprocitanePoruke != 0 : x.neprocitanePoruke == 0).length || 0;
  }
}
