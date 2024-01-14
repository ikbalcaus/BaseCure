import { Component } from '@angular/core';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-medicines',
  standalone: true,
  imports: [CommonModule, FilterComponent, ItemListComponent],
  templateUrl: './user-medicines.component.html',
  styleUrl: './user-medicines.component.css'
})
export class UserMedicinesComponent {

}
