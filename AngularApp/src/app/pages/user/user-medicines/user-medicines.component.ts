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

  req: any = { korisnikId: this.authService.getAuthToken().korisnikId };
  res: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/lijekovi/apoteka?ustanovaId=" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => this.res = res
    );
  }

  addOrder(medicineId: number) {
    this.req.lijekId = medicineId;
    this.httpClient.post(serverSettings.address + "/narudzba", this.req).subscribe(
      () => this.alertService.setAlert("success", "Uspješno ste dodali lijek u korpu")
    );
  }
}
