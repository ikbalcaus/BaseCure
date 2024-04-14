import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { AlertService } from '../../../services/alert.service';

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
    private alertService: AlertService
  ) {}

  req: any;

  formSubmit(loginForm: any) {
    this.req = {
      id: 0,
      ustanovaId: 0,
      nazivLijeka: loginForm.nazivLijeka,
      cijenaLijeka: loginForm.cijenaLijeka,
      kolicina: loginForm.kolicina,
      opisLijeka: loginForm.opisLijeka,
      zahtijevaRecept: loginForm.zahtijevaRecept || false
    };
    this.httpClient.post(serverSettings.address + "/lijekovi", this.req).subscribe(
      res => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno dodan");
      }
    );
  }
}
