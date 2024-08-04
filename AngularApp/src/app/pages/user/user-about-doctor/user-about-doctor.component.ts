import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { ViewMapComponent } from '../../../components/view-map/view-map.component';

@Component({
  selector: 'app-user-about-doctor',
  standalone: true,
  imports: [CommonModule, RouterModule, ViewMapComponent],
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
