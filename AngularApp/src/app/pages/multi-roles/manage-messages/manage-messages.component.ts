import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-manage-messages',
  standalone: true,
  imports: [CommonModule, TranslateModule],
  templateUrl: './manage-messages.component.html',
  styleUrl: './manage-messages.component.css'
})
export class ManageMessagesComponent {
  constructor() {}

  res: any;

  countMessages(status: string) {
    
  }
}
