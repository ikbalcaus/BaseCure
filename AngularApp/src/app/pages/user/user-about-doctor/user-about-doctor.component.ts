import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { MapComponent } from '../../../components/map/map.component';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-about-doctor',
  standalone: true,
  imports: [CommonModule, RouterModule, MapComponent, TranslateModule],
  templateUrl: './user-about-doctor.component.html',
  styleUrl: './user-about-doctor.component.css'
})
export class UserAboutDoctorComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  res: any;

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.httpClient.get<any>(`${serverSettings.address}/ljekari/${id}`).subscribe(
        res => {
          this.res = res;
          this.httpClient.get(`${serverSettings.address}/slika/ljekari/${id}`, { responseType: "blob" }).subscribe(
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
