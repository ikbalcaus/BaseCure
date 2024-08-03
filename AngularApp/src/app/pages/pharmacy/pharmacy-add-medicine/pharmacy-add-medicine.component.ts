import { CommonModule } from '@angular/common';
import { HttpClient} from '@angular/common/http';
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

  AddMedicine(data: any) {
    const formData = new FormData();
    formData.append('naziv', data.naziv);
    formData.append('opis', data.opis);
    formData.append('cijena', data.cijena);
    formData.append('kolicina', data.kolicina);
    formData.append('zahtijevaRecept', data.zahtijevaRecept || false);
    formData.append('ustanovaId', this.authService.getAuthToken().ustanovaId);
    
    const fileInput = (document.querySelector('input[name="slika"]') as HTMLInputElement);
    if (fileInput.files?.length) {
        formData.append('slika', fileInput.files[0]);
    }

    this.httpClient.post(serverSettings.address + "/lijekovi", formData).subscribe(
        () => {
            this.router.navigateByUrl("/apoteka/lijekovi");
            this.alertService.setAlert("success", "Lijek je uspješno dodan");
        },
        error => {
            this.alertService.setAlert("error", "Došlo je do greške prilikom dodavanja lijeka");
            console.error('Error adding medicine:', error);
        }
    );
}

  
}
