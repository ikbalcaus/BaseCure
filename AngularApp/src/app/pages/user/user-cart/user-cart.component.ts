import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from '../../../components/item-list/item-list.component';

@Component({
  selector: 'app-user-cart',
  standalone: true,
  imports: [CommonModule, ItemListComponent],
  templateUrl: './user-cart.component.html',
  styleUrl: './user-cart.component.css'
})
export class UserCartComponent {

}
