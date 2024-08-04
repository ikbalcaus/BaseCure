import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { AlertService } from '../../../services/alert.service';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { ModalComponent } from '../../../components/modal/modal.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-pharmacy-orders-details',
  standalone: true,
  imports: [CommonModule, ItemListComponent, ModalComponent],
  templateUrl: './pharmacy-orders-details.component.html',
  styleUrl: './pharmacy-orders-details.component.css'
})
export class PharmacyOrdersDetailsComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService
  ) {}

  narudzbe: any;
  redniBroj: any = this.route.snapshot.paramMap.get("redniBroj")
  status: any = this.route.snapshot.paramMap.get("status");
  showModalSubmitForm: boolean = false;
  showModalDeleteMedicine: boolean = false;
  tempNarudzbaId: number = 0;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "/detalji?status=" + this.status + "&redniBroj=" + this.redniBroj).subscribe(
      res => {
        this.narudzbe = res;
        this.narudzbe.forEach((medicine: any) => {
          this.httpClient.get(serverSettings.address + "/slika/lijekovi/" + medicine.lijekId, { responseType: "blob" }).subscribe(
            imageBlob => {
              const reader = new FileReader();
              reader.onload = () => {
                medicine.slika = reader.result as string;
              };
              reader.readAsDataURL(imageBlob);
            }
          );
        });
        if(this.narudzbe.length == 0) {
          this.router.navigateByUrl("apoteka/narudzbe");
        }
      }
    );
  }

  sumPrice() {
    return this.narudzbe.map((x: any) => x.cijena).reduce((a: number, b: number) => a + b, 0);
  }

  showModalDeleteMedicineFunc(narudzbaId: number) {
    this.tempNarudzbaId = narudzbaId;
    this.showModalDeleteMedicine = true;
  }

  deleteMedicine() {
    this.httpClient.delete(serverSettings.address + "/narudzbe/" + this.tempNarudzbaId).subscribe(
      () => this.ngOnInit()
    );
  }

  confirmOrder() {
    if(this.status == "aktivno") {
      this.httpClient.put(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "?redniBroj=" + this.redniBroj, null).subscribe(
        () => {
          this.ngOnInit();
          this.showModalSubmitForm = false;
          this.router.navigateByUrl("apoteka/narudzbe");
          this.alertService.setAlert("success", "Uspješno ste isporučili narudžbu");
        },
        () => this.alertService.setAlert("danger", "Nemate zaliha lijekova")
      );
    }
    else if(this.status == "isporuceno") {
      this.httpClient.delete(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "?redniBroj=" + this.redniBroj).subscribe(
        () => {
          this.ngOnInit();
          this.showModalSubmitForm = false;
          this.router.navigateByUrl("apoteka/narudzbe");
          this.alertService.setAlert("success", "Uspješno ste izbrisali narudžbu");
        }
      );
    }
  }
}
