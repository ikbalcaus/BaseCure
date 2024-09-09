import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AlertService } from '../../../services/alert.service';
import { ModalComponent } from '../../../components/modal/modal.component';
import { TranslateModule } from '@ngx-translate/core';
import { ChangePasswordComponent } from '../../../components/change-password/change-password.component';

@Component({
  selector: 'app-edit-medical-institution',
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent, ChangePasswordComponent, TranslateModule],
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
  showChangePassword: boolean = false;
  image: any;

  ngOnInit() {
    const id = this.authService.getAuthToken().ustanovaId;
    if(id) {
      this.httpClient.get<any>(`${serverSettings.address}/ustanoveZdravstva?id=${id}`).subscribe(
        res => {
          this.res = res;
          this.httpClient.get(`${serverSettings.address}/slika/ustanoveZdravstva/${id}`, { responseType: "blob" }).subscribe(
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

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;
    if(input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.image = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  EditMedicalInstitution(data: any) {
    const formData = new FormData();
    const formAppend = (key: string, value: any) => { if(value != null && value != undefined) formData.append(key, value) }
    formAppend("naziv", data.naziv);
    formAppend("grad", data.grad);
    formAppend("adresa", data.adresa);
    formAppend("telefon", data.telefon);
    formAppend("mailAdresa", data.mailAdresa);
    formAppend("brojTelefona", data.brojTelefona);
    formAppend("cijenaDostave", data.cijenaDostave);
    formAppend("opis", data.opis);

    const fileInput = (document.getElementById("imageInput") as HTMLInputElement);
    if(fileInput.files?.length) formData.append("slika", fileInput.files[0]);

    this.httpClient.put(serverSettings.address + "/ustanoveZdravstva/" + this.authService.getAuthToken().ustanovaId, formData).subscribe(
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste promjenili podatke");
      }
    );
  }
}
