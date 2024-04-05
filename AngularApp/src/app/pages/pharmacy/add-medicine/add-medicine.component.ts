import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { backendSettings } from '../../../backend-settings';

@Component({
  selector: 'app-add-medicine',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-medicine.component.html',
  styleUrl: './add-medicine.component.css'
})
export class AddMedicineComponent {
  constructor(private httpClient: HttpClient) {}

  req: any;

  formSubmit(loginForm: any) {
    this.req = {
      id: 0,
      ustanovaId: 0,
      nazivLijeka: loginForm.nazivLijeka,
      opisLijeka: loginForm.opisLijeka,
      zahtijevaRecept: loginForm.zahtijevaRecept || false
    };
    this.httpClient.post(backendSettings.address + "/lijekovi", this.req).subscribe();
  }
}
