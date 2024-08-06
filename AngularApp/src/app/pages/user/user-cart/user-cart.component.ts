import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { AuthService } from '../../../services/auth.service';
import { ModalComponent } from '../../../components/modal/modal.component';
import { AlertService } from '../../../services/alert.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, ItemListComponent, ModalComponent, TranslateModule],
  templateUrl: './user-cart.component.html',
  styleUrl: './user-cart.component.css'
})
export class UserCartComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private router: Router,
    private alertService: AlertService
  ) {}

  korisnik: any;
  narudzbe: any;
  gradovi: any;
  showModal: boolean = false;

  ngOnInit() {
    this.httpClient.get<any>(serverSettings.address + "/korisnici/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => {
        this.korisnik = res;
        if(res.ime == null) this.korisnik.imePrezime = res.prezime;
        else if(res.prezime == null) this.korisnik.imePrezime = res.ime;
        else this.korisnik.imePrezime = res.ime + " " + res.prezime
      }
    );
    this.httpClient.get(serverSettings.address + "/narudzbe/korisnik/" + this.authService.getAuthToken().korisnikId).subscribe(
      res => {
        this.narudzbe = res;
        this.narudzbe.forEach((medication: any) => {
          this.httpClient.get(serverSettings.address + "/slika/lijekovi/" + medication.lijekId, { responseType: "blob" }).subscribe(
            imageBlob => {
              const reader = new FileReader();
              reader.onload = () => {
                medication.slika = reader.result as string;
              };
              reader.readAsDataURL(imageBlob);
            }
          );
        });
      }
    );
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  sumPrice() {
    return this.narudzbe.map((x: any) => x.cijena).reduce((a: number, b: number) => a + b, 0);
  }

  deliveryPrice() {
    const deliveryPriceMap = new Map<string, number>();
    this.narudzbe.forEach((narudzba: any) => {
      if(!deliveryPriceMap.has(narudzba.nazivUstanove)) {
        deliveryPriceMap.set(narudzba.nazivUstanove, narudzba.cijenaDostave);
      }
    });
    const sum = Array.from(deliveryPriceMap.values()).reduce((a, b) => a + b, 0);
    return sum;
  }

  removeOrder(narudzbaId: number) {
    this.httpClient.delete(serverSettings.address + "/narudzbe/" + narudzbaId).subscribe(
      () =>  this.ngOnInit()
    );
  }

  confirmOrder(formData: any) {
    this.httpClient.put(serverSettings.address + "/narudzbe/korisnik/" + this.authService.getAuthToken().korisnikId, formData).subscribe(
      () => {
        this.ngOnInit();
        this.showModal = false;
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste potvrdili narudžbu");
      },
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("danger", "Niste unijeli ispravne podatke");
      }
    );
  }
}
