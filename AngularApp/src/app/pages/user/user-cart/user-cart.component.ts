import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { AuthService } from '../../../services/auth.service';
import { ModalComponent } from '../../../components/modal/modal.component';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-user-cart',
  standalone: true,
  imports: [CommonModule, ItemListComponent, ModalComponent],
  templateUrl: './user-cart.component.html',
  styleUrl: './user-cart.component.css'
})
export class UserCartComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  korisnik: any;
  narudzbe: any;
  showModal: boolean = false;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.korisnik = res
    );
    this.httpClient.get(serverSettings.address + "/narudzbe/korisnik/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => this.narudzbe = res
    );
  }

  sumPrice() {
    return this.narudzbe.map((x: any) => x.cijenaLijeka).reduce((a: number, b: number) => a + b, 0);
  }

  removeOrder(narudzbaId: number) {
    this.httpClient.delete(serverSettings.address + "/narudzbe/" + narudzbaId).subscribe(
      () =>  this.ngOnInit()
    );
  }

  confirmOrder() {
    this.httpClient.put(serverSettings.address + "/narudzbe/korisnik/" + this.authService.getAuthToken().korisnikId, null).subscribe(
      () => {
        this.ngOnInit();
        this.showModal = false;
        this.alertService.setAlert("success", "Uspješno ste potvrdili narudžbu");
      }
    );
  }
}
