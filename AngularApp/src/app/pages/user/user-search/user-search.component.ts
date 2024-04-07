import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { CardComponent } from "../../../components/card/card.component";
import { HttpClient } from '@angular/common/http';
import { backendSettings } from '../../../backend-settings';

@Component({
  selector: 'app-user-search',
  standalone: true,
  templateUrl: './user-search.component.html',
  styleUrl: './user-search.component.css',
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
    
    this.httpClient.post(backendSettings.address + "/ustanveZdravstva/search", this.req).subscribe(
      res => {
        this.res = res;
      }
    );
  }
}
