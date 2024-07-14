import { Component } from '@angular/core';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-user-medicines',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent],
  templateUrl: './user-medicines.component.html',
  styleUrl: './user-medicines.component.css'
})
export class UserMedicinesComponent {
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
      res => this.res = res
    );
  }

  addOrder(medicineId: number) {
    let req = {
      korisnikId: this.authService.getAuthToken().korisnikId,
      lijekId: medicineId
    };
    this.httpClient.post(serverSettings.address + "/narudzbe", req).subscribe(
      () => this.alertService.setAlert("success", "Uspješno ste dodali lijek u korpu")
    );
  }
}
