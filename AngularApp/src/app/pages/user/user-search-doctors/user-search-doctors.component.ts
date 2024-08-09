import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { CardComponent } from '../../../components/card/card.component';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ActivatedRoute } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-user-doctors',
  standalone: true,
  imports: [CommonModule, FilterComponent, CardComponent, TranslateModule],
  templateUrl: './user-search-doctors.component.html',
  styleUrl: './user-search-doctors.component.css'
})
export class UserSearchDoctorsComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  req: any = {};
  res: any;

  ngOnInit() {
    this.getSearchResults(["", ""])
  }

  getSearchResults($event: Array<string>) {
    this.req.imePrezime = $event[0];
    this.req.specijalizacija = $event[1];
    
    this.httpClient.get(serverSettings.address + "/filter/ljekari/" + this.route.snapshot.paramMap.get("id") + "?imePrezime=" + this.req.imePrezime + "&specijalizacija=" + this.req.specijalizacija).subscribe(
      res => {
        this.res = res;
        this.res.forEach((doctor: any) => {
          this.httpClient.get(serverSettings.address + "/slika/ljekari/" + doctor.ljekarId, { responseType: "blob" }).subscribe(
            imageBlob => {
              const reader = new FileReader();
              reader.onload = () => {
                doctor.slika = reader.result as string;
              };
              reader.readAsDataURL(imageBlob);
            }
          );
        });
      }
    );
  }
}
