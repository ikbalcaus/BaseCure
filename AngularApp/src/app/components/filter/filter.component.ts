import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css'
})
export class FilterComponent {
  @Input() input_text1 = "";
  @Input() input_text2 = "";
  @Input() input_link1 = "";
  @Input() input_link2 = "";
}
