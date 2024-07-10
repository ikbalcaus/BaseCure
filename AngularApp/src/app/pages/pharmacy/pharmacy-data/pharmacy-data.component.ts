import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-pharmacy-data',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pharmacy-data.component.html',
  styleUrl: './pharmacy-data.component.css'
})
export class PharmacyDataComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  res: any;
  gradovi: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/ustanveZdravstva?id=" + this.authService.getAuthToken().ustanovaId).subscribe(
      res => this.res = res
    )
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  formSubmit(data: any) {

  }
}
