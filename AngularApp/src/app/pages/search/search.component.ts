import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../components/filter/filter.component';
import { CardComponent } from "../../components/card/card.component";

@Component({
  selector: 'app-search',
  standalone: true,
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  imports: [CommonModule, FilterComponent, CardComponent]
})
export class SearchComponent {

}
