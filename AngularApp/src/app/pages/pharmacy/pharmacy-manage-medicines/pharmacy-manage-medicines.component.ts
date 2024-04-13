import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { HttpClient } from '@angular/common/http';
import { backendSettings } from '../../../backend-settings';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { Router } from '@angular/router';

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
    private router: Router
  ) {}
  
  req: any = {};
  res: any;

  ngOnInit() {
    this.httpClient.get(backendSettings.address + "/lijekovi").subscribe(
      res => {
        this.res = res;
      }
    )
  }

  getSearchResults($event: Array<string>) {
    this.req.naziv = $event[0];
    this.req.grad = $event[1];
    
    this.httpClient.get(backendSettings.address + "/lijekovi/search?NazivLijeka=" + this.req.naziv + "&OpisLijeka=" + this.req.grad + "", this.req).subscribe(
      res => {
        this.res = res;
      }
    );
  }

  editMedicine(lijekId: number) {
    this.router.navigateByUrl("/apoteka/uredi/" + lijekId);
  }
}
