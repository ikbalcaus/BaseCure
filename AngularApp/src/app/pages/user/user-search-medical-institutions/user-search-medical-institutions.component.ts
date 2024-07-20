import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { CardComponent } from "../../../components/card/card.component";
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';

@Component({
  selector: 'app-user-search',
  standalone: true,
  templateUrl: './user-search-medical-institutions.component.html',
  styleUrl: './user-search-medical-institutions.component.css',
  imports: [CommonModule, FilterComponent, CardComponent]
})
export class UserSearchMedicalInstitutionComponent {
  constructor(private httpClient: HttpClient) {}

  req: any = {};
  res: any[] = [];
  ngOnInit() {
    this.getSearchResults(["", ""]);
  }

  getSearchResults($event: Array<string>) {
    this.req.tipUstanove = $event[0];
    this.req.grad = $event[1];
    
    this.httpClient.get<any[]>(`${serverSettings.address}/filter/ustanoveZdravstva?tipUstanove=${this.req.tipUstanove}&grad=${this.req.grad}`).subscribe(
      res => {
        this.res = res;
        this.res.forEach(institution => {
          this.httpClient.get(`${serverSettings.address}/slika/ustanovaZdravstva/${institution.ustanovaId}`, { responseType: 'blob' }).subscribe(
            imageBlob => {
              const reader = new FileReader();
              reader.onload = () => {
                institution.slika = reader.result as string;
              };
              reader.readAsDataURL(imageBlob);
            }
          );
        });
      }
    );
  }
}
