import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterComponent } from '../../../components/filter/filter.component';
import { CardComponent } from "../../../components/card/card.component";
import { HttpClient } from '@angular/common/http';
import { myCofnig } from '../../../myconfig';
import { UstanovaZdravstva } from '../../../endpoints/ustanoveZdravstva';

@Component({
  selector: 'app-user-search',
  standalone: true,
  templateUrl: './user-search.component.html',
  styleUrl: './user-search.component.css',
  imports: [CommonModule, FilterComponent, CardComponent]
})
export class UserSearchComponent {
  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.getSearchResults(["", ""])
  }

  req: UstanovaZdravstva = { naziv: "", grad: "" };
  res: Array<UstanovaZdravstva> = [];

  getSearchResults($event: Array<string>) {
    this.req.naziv = $event[0];
    this.req.grad = $event[1];
    
    this.httpClient.post<Array<UstanovaZdravstva>>(myCofnig.backendAddress + "/ustanveZdravstva/search", this.req).subscribe(
      res => {
        this.res = res;
      }
    );
  }
}
