import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-pharmacy-manage-cures',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent],
  templateUrl: './pharmacy-manage-medicines.component.html',
  styleUrl: './pharmacy-manage-medicines.component.css'
})
export class PharmacyManageMedicinesComponent {
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
      res => this.res = res
    );
  }

  editMedicine(lijekId: number) {
    this.router.navigateByUrl("/apoteka/uredi/" + lijekId);
  }
}
