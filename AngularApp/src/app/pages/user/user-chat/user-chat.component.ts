import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AlertService } from '../../../services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-chat',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-chat.component.html',
  styleUrl: './user-chat.component.css'
})
export class UserChatComponent {
  constructor(
    private router: Router,
    private alertService: AlertService
  ) {}

  updateAppointment(arg0: string, arg1: string) {
    
  }
  
  confirmAppointment() {
    this.router.navigateByUrl("/");
    this.alertService.setAlert("success", "Uspjesno ste potvrdili termin");
  }
}
