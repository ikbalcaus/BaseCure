import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { ModalComponent } from '../../../components/modal/modal.component';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-pharmacy-edit-medicine',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent],
  templateUrl: './pharmacy-edit-medicine.component.html',
  styleUrl: './pharmacy-edit-medicine.component.css'
})
export class PharmacyEditMedicineComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService
  ) {}

  req: any;
  res: any;
  showModal: boolean = false;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res
        this.httpClient.get(`${serverSettings.address}/slika/lijek/${this.route.snapshot.paramMap.get("id")}`, { responseType: 'blob' }).subscribe(
          imageBlob => {
            const reader = new FileReader();
            reader.onload = () => {
              this.res.slika = reader.result as string;
            };
            reader.readAsDataURL(imageBlob);
          }
        );
      }
    );
  }

  EditMedicine(data: any) {
    const formData = new FormData();
    formData.append('naziv', data.naziv);
    formData.append('cijena', data.cijena);
    formData.append('kolicina', data.kolicina);
    formData.append('opis', data.opis);
    formData.append('zahtijevaRecept', data.zahtijevaRecept || false);
    
    const fileInput = (document.querySelector('input[name="slika"]') as HTMLInputElement);
    if (fileInput.files?.length) {
      formData.append('slika', fileInput.files[0]);
    }
  
    this.httpClient.put(serverSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id"), formData).subscribe(
      () => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno uređen");
      },
      error => {
        console.error('Error updating medicine:', error);
        this.alertService.setAlert("danger", "Failed to update medicine. Please try again.");
      }
    );
  }

  deleteMedicine() {
    this.httpClient.delete(serverSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      () => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno obrisan");
      }
    );
  }
}
