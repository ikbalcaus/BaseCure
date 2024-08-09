import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-pharmacy-manage-cures',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent, TranslateModule],
  templateUrl: './pharmacy-manage-medications.component.html',
  styleUrl: './pharmacy-manage-medications.component.css'
})
export class PharmacyManageMedicationsComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService
  ) {}
  
  req: any = {};
  res: any;

  ngOnInit() {
    this.getSearchResults(["", ""]);
  }

  getSearchResults($event: Array<string>) {
    this.req.naziv = $event[0];
    this.req.opis = $event[1];
    
    this.httpClient.get(serverSettings.address + "/filter/lijekovi/" + this.authService.getAuthToken().ustanovaId + "?naziv=" + this.req.naziv + "&opis=" + this.req.opis, this.req).subscribe(
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

  editMedication(lijekId: number) {
    this.router.navigateByUrl("/apoteka/uredi/" + lijekId);
  }
}
