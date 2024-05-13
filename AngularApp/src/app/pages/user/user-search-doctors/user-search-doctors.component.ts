import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { CardComponent } from '../../../components/card/card.component';
import { FilterComponent } from '../../../components/filter/filter.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-doctors',
  standalone: true,
  imports: [CommonModule, FilterComponent, CardComponent],
  templateUrl: './user-search-doctors.component.html',
  styleUrl: './user-search-doctors.component.css'
})
export class UserDoctorsComponent {
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
    this.req.naziv = $event[0];
    this.req.grad = $event[1];
    
    this.httpClient.get(serverSettings.address + "/ljekari?ustanovaId=" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => this.res = res
    );
  }
}
