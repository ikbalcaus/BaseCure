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
  image: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res
        this.httpClient.get(`${serverSettings.address}/slika/lijekovi/${this.route.snapshot.paramMap.get("id")}`, { responseType: "blob" }).subscribe(
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

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.image = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  EditMedicine(data: any) {
    const formData = new FormData();
    const formAppend = (key: string, value: any) => { if(value != null && value != undefined) formData.append(key, value) }
    formAppend("naziv", data.naziv);
    formAppend("cijena", data.cijena);
    formAppend("kolicina", data.kolicina);
    formAppend("opis", data.opis);
    formAppend("zahtijevaRecept", data.zahtijevaRecept || false);
    
    const fileInput = (document.getElementById("imageInput") as HTMLInputElement);
    if(fileInput.files?.length) formData.append("slika", fileInput.files[0]);
  
    this.httpClient.put(serverSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id"), formData).subscribe(
      () => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno uređen");
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
