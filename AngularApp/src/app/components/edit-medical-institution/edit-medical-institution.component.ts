import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { serverSettings } from '../../server-settings';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../services/alert.service';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-edit-medical-institution',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent],
  templateUrl: './edit-medical-institution.component.html',
  styleUrl: './edit-medical-institution.component.css'
})
export class EditMedicalInstitutionComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  res: any;
  gradovi: any;
  showModal: boolean = false;

  ngOnInit() {
    const id = this.authService.getAuthToken().ustanovaId;
    if (id) {
      this.httpClient.get<any>(`${serverSettings.address}/ustanoveZdravstva?id=${id}`).subscribe(
        res => {
          this.res = res;
          this.httpClient.get(`${serverSettings.address}/slika/ustanovaZdravstva/${id}`, { responseType: 'blob' }).subscribe(
            imageBlob => {
              const reader = new FileReader();
              reader.onload = () => {
                this.res.slika = reader.result as string;
              };
              reader.readAsDataURL(imageBlob);
            }
          );
        }
      );
    }
    this.httpClient.get(serverSettings.address + "/gradovi/").subscribe(
      res => this.gradovi = res
    )
  }

  EditMedicalInstitution(data: any) {
    this.httpClient.put(serverSettings.address + "/ustanoveZdravstva/" + this.authService.getAuthToken().ustanovaId, data).subscribe(
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste promjenili podatke");
      }
    )
  }
}
