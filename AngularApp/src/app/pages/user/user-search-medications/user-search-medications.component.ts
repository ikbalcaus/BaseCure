import { Component } from '@angular/core';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { AlertService } from '../../../services/alert.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-medications',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent, TranslateModule],
  templateUrl: './user-search-medications.component.html',
  styleUrl: './user-search-medications.component.css'
})
export class UserSearchMedicationsComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  req: any = {};
  res: any;

  ngOnInit() {
    this.getSearchResults(["", ""]);
  }

  getSearchResults($event: Array<string>) {
    this.req.naziv = $event[0];
    this.req.opis = $event[1];
    
    this.httpClient.get(serverSettings.address + "/filter/lijekovi/" + this.route.snapshot.paramMap.get("id") + "?naziv=" + this.req.naziv + "&opis=" + this.req.opis, this.req).subscribe(
      res => {
        this.res = res;
        this.res.forEach((medication: any) => {
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
  }

  addOrder(medicationId: number) {
    let req = {
      korisnikId: this.authService.getAuthToken().korisnikId,
      lijekId: medicationId
    };
    this.httpClient.post(serverSettings.address + "/narudzbe", req).subscribe(
      () => this.alertService.setAlert("success", "Uspješno ste dodali lijek u korpu")
    );
  }
}
