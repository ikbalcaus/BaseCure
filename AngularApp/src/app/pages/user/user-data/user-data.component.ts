import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { serverSettings } from '../../../server-settings';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../../services/alert.service';
import { ModalComponent } from '../../../components/modal/modal.component';
import { TranslateModule } from '@ngx-translate/core';
import { ChangePasswordComponent } from '../../../components/change-password/change-password.component';

@Component({
  selector: 'app-user-data',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent, ChangePasswordComponent, TranslateModule],
  templateUrl: './user-data.component.html',
  styleUrl: './user-data.component.css'
})
export class UserDataComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  res: any;
  gradovi: any;
  showModal: boolean = false;
  showChangePassword: boolean = false;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.res = res
    )
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  EditUser(data: any) {
    this.httpClient.put(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId, data).subscribe(
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste promijenili podatke");
      }
    )
  }
}
