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

  korisnik: any;
  narudzbe: any;
  korisnikId: any = this.route.snapshot.paramMap.get("korisnikId")
  status: any = this.route.snapshot.paramMap.get("status");
  showModalSubmitForm: boolean = false;
  showModalDeleteMedicine: boolean = false;
  tempNarudzbaId: number = 0;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.route.snapshot.paramMap.get("korisnikId")).subscribe(
      res => this.korisnik = res
    );
    this.httpClient.get(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "/" + this.status + "/korisnik/" + this.korisnikId).subscribe(
      res => this.narudzbe = res
    );
  }

  sumPrice() {
    return this.narudzbe.map((x: any) => x.cijenaLijeka).reduce((a: number, b: number) => a + b, 0);
  }

  showModalDeleteMedicineFunc(narudzbaId: number) {
    this.tempNarudzbaId = narudzbaId;
    this.showModalDeleteMedicine = true;
  }

  deleteMedicine() {
    this.httpClient.delete(serverSettings.address + "/narudzbe/" + this.tempNarudzbaId).subscribe(
      () =>  this.ngOnInit()
    );
  }

  confirmOrder() {
    if(this.status == "aktivno") {
      this.httpClient.put(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "/korisnik/" + this.korisnikId, null).subscribe(
        () => {
          this.ngOnInit();
          this.showModalSubmitForm = false;
          this.alertService.setAlert("success", "Uspješno ste isporučili narudžbe");
          this.router.navigateByUrl("apoteka/narudzbe");
        }
      );
    }
    else if(this.status == "isporuceno") {
      this.httpClient.delete(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId + "/korisnik/" + this.korisnikId).subscribe(
        () => {
          this.ngOnInit();
          this.showModalSubmitForm = false;
          this.alertService.setAlert("success", "Uspješno ste izbrisali narudžbe");
          this.router.navigateByUrl("apoteka/narudzbe");
        }
      );
    }
  }
}
