import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { ViewMapComponent } from '../../../components/view-map/view-map.component';

@Component({
  selector: 'app-user-about',
  standalone: true,
  imports: [CommonModule, RouterModule, ViewMapComponent],
  templateUrl: './user-about-medical-institution.component.html',
  styleUrl: './user-about-medical-institution.component.css'
})
export class UserAboutMedicalInstitutionComponent {
  res: any;
  lat: any;
  long: any;

  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.httpClient.get<any>(`${serverSettings.address}/ustanoveZdravstva?id=${id}`).subscribe(
        res => {
          this.res = res;
          // Fetch image for the medical institution
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
  }
}
