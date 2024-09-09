import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { MapComponent } from '../../../components/map/map.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-about',
  standalone: true,
  imports: [CommonModule, RouterModule, MapComponent, TranslateModule],
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
    const id = this.route.snapshot.paramMap.get("id");
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
  }
}
