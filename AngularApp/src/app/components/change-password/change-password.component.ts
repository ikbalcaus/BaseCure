import { Component, EventEmitter, Output } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { AlertService } from '../../services/alert.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../server-settings';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [CommonModule, FormsModule, TranslateModule],
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  @Output() onClose = new EventEmitter();
  showModal: boolean = false;

  onCloseHandler() {
    this.onClose.emit();
  }

  changePassword(data: any) {
    data.korisnikId = this.authService.getAuthToken().korisnikId;
    this.httpClient.post(serverSettings.address + "/auth/changePassword", data).subscribe(
      () => {
        this.alertService.setAlert("success", "Uspješno ste promjenili lozinku");
        this.onClose.emit();
      },
      (err) => this.alertService.setAlert("danger", err.error.message)
    )
  }
}
