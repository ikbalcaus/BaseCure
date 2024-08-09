import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-doctor-manage-messages',
  standalone: true,
  imports: [CommonModule, TranslateModule],
  templateUrl: './doctor-manage-messages.component.html',
  styleUrl: './doctor-manage-messages.component.css'
})
export class DoctorManageMessagesComponent {
  constructor() {}

  res: any;

  countMessages(status: string) {
    
  }
}
