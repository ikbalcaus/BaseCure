import { CommonModule } from '@angular/common';
import { HttpClient} from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { AlertService } from '../../../services/alert.service';
import { AuthService } from '../../../services/auth.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-pharmacy-add-medication',
  standalone: true,
  imports: [CommonModule, FormsModule, TranslateModule],
  templateUrl: './pharmacy-add-medication.component.html',
  styleUrl: './pharmacy-add-medication.component.css'
})
export class PharmacyAddMedicationComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  image: any;

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;
    if(input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.image = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  AddMedication(data: any) {
    const formData = new FormData();
    const formAppend = (key: string, value: any) => { if(value != null && value != undefined) formData.append(key, value) }
    formAppend("naziv", data.naziv);
    formAppend("opis", data.opis);
    formAppend("cijena", data.cijena);
    formAppend("kolicina", data.kolicina);
    formAppend("zahtijevaRecept", data.zahtijevaRecept || false);
    formAppend("ustanovaId", this.authService.getAuthToken().ustanovaId);

    const fileInput = (document.getElementById("imageInput") as HTMLInputElement);
    if(fileInput.files?.length) formData.append("slika", fileInput.files[0]);

    this.httpClient.post(serverSettings.address + "/lijekovi", formData).subscribe(
      () => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno dodan");
      }
    );
  }
}
