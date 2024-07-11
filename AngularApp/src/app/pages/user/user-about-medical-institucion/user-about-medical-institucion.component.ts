import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';
import { MapComponent } from '../../../components/map/map.component';

@Component({
  selector: 'app-user-about',
  standalone: true,
  imports: [CommonModule, RouterModule, MapComponent],
  templateUrl: './user-about-medical-institucion.component.html',
  styleUrl: './user-about-medical-institucion.component.css'
})
export class UserAboutMedicalInstitutionComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  res: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/ustanveZdravstva?id=" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => this.res = res
    );
  }
}
