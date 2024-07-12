import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { serverSettings } from '../../../server-settings';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-user-data',
  standalone: true,
  imports: [CommonModule, FormsModule],
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

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.res = res
    )
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  formSubmit(data: any) {

  }
}
