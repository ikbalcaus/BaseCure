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

@Component({
  selector: 'app-user-data',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent, TranslateModule],
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
  passwordChange: any = {
    oldPassword: '',
    newPassword: '',
    repeatNewPassword: ''
  };

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.res = res
    )
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  EditUser(data: any, passwordChange: any) {
    if (passwordChange.newPassword && passwordChange.newPassword !== passwordChange.repeatNewPassword) {
      this.alertService.setAlert("error", "Nove lozinke se ne podudaraju");
      return;
    }

    const updateData = { ...data };
    if (passwordChange.oldPassword && passwordChange.newPassword) {
      updateData.passwordChange = passwordChange;
    }

    this.httpClient.put(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId, updateData).subscribe(
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste promijenili podatke");
      }
    )
  }
}
