import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { backendSettings } from '../../../backend-settings';
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
    this.httpClient.get(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res
        console.log(this.res)
      }
    )
  }

  formSubmit(loginForm: any) {
    this.req = {
      nazivLijeka: loginForm.nazivLijeka,
      cijenaLijeka: loginForm.cijenaLijeka,
      kolicina: loginForm.kolicina,
      opisLijeka: loginForm.opisLijeka,
      zahtijevaRecept: loginForm.zahtijevaRecept || false
    };
    this.httpClient.put(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id"), this.req).subscribe(
      res => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno uređen");
      }
    );
  }

  deleteMedicine() {
    this.httpClient.delete(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.router.navigateByUrl("/apoteka/lijekovi");
        this.alertService.setAlert("success", "Lijek je uspješno obrisan");
      }
    );
  }
}