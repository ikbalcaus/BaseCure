import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { CardComponent } from "../../../components/card/card.component";

@Component({
  selector: 'app-user-search',
  standalone: true,
  templateUrl: './user-search.component.html',
  styleUrl: './user-search.component.css',
  imports: [CommonModule, FilterComponent, CardComponent]
})
export class UserSearchComponent {

}
