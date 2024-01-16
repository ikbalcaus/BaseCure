import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-view-medical-record',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './view-medical-record.component.html',
  styleUrl: './view-medical-record.component.css'
})
export class ViewMedicalRecordComponent {
  @Input() id: string = "";
  @Input() name: string = "";
  @Input() date: string = "";
}
