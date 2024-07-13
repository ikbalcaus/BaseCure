import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { CardComponent } from "../../../components/card/card.component";
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';

@Component({
  selector: 'app-user-search',
  standalone: true,
  templateUrl: './user-search-medical-institucions.component.html',
  styleUrl: './user-search-medical-institucions.component.css',
  imports: [CommonModule, FilterComponent, CardComponent]
})
export class UserSearchComponent {
  constructor(private httpClient: HttpClient) {}

  req: any = {};
  res: any;

  ngOnInit() {
    this.getSearchResults(["", ""])
  }

  getSearchResults($event: Array<string>) {
    this.req.naziv = $event[0];
    this.req.grad = $event[1];
    
    this.httpClient.get(serverSettings.address + "/ustanoveZdravstva/search?naziv=" + this.req.naziv + "&grad=" + this.req.grad).subscribe(
      res => this.res = res
    );
  }
}
