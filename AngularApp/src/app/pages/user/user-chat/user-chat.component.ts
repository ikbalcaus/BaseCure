import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-chat',
  standalone: true,
  imports: [CommonModule, FormsModule, TranslateModule],
  templateUrl: './user-chat.component.html',
  styleUrl: './user-chat.component.css'
})
export class UserChatComponent {
  
}
