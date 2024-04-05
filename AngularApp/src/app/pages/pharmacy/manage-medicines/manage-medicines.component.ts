import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { HttpClient } from '@angular/common/http';
import { backendSettings } from '../../../backend-settings';
import { ItemListComponent } from '../../../components/item-list/item-list.component';

@Component({
  selector: 'app-manage-cures',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent],
  templateUrl: './manage-medicines.component.html',
  styleUrl: './manage-medicines.component.css'
})
export class ManageMedicinesComponent {
  constructor(private httpClient: HttpClient) {}
  
  req: any;
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
    
    this.httpClient.post(backendSettings.address + "/lijekovi/search", this.req).subscribe(
      res => {
        this.res = res;
      }
    );
  }
}
