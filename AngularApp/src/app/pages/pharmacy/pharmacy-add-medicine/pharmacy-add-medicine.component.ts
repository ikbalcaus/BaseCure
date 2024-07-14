import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { AlertService } from '../../../services/alert.service';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-pharmacy-add-medicine',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pharmacy-add-medicine.component.html',
  styleUrl: './pharmacy-add-medicine.component.css'
})
export class PharmacyAddMedicineComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  req: any;

  AddMedicine(data: any) {
    this.req = {
      id: 0,
      ustanovaId: this.authService.getAuthToken().ustanovaId,
      naziv: data.naziv,
      cijena: data.cijena,
      kolicina: data.kolicina,
      opis: data.opis,
      zahtijevaRecept: data.zahtijevaRecept || false
    };
    this.httpClient.post(serverSettings.address + "/lijekovi", this.req).subscribe(
      () => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno dodan");
      }
    );
  }
}
