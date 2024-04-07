import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { backendSettings } from '../../../backend-settings';

@Component({
  selector: 'app-pharmacy-edit-medicine',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pharmacy-edit-medicine.component.html',
  styleUrl: './pharmacy-edit-medicine.component.css'
})
export class PharmacyEditMedicineComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  req: any;
  res: any;

  ngOnInit() {
    this.httpClient.get(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res
        console.log(this.res)
      }
    )
  }

  formSubmit(loginForm: any) {
    this.req = {
      ustanovaId: 0,
      nazivLijeka: loginForm.nazivLijeka,
      opisLijeka: loginForm.opisLijeka,
      zahtijevaRecept: loginForm.zahtijevaRecept || false
    };
    this.httpClient.put(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id"), this.req).subscribe(
      res => {
        this.router.navigateByUrl("/apoteka/lijekovi");
      }
    );
  }

  deleteMedicine() {
    this.httpClient.delete(backendSettings.address + "/lijekovi/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.router.navigateByUrl("/apoteka/lijekovi");
      }
    );
  }
}
