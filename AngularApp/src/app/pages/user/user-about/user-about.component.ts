import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { serverSettings } from '../../../server-settings';

@Component({
  selector: 'app-user-about',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './user-about.component.html',
  styleUrl: './user-about.component.css'
})
export class UserAboutComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  res: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/ustanveZdravstva/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res;
      }
    );
  }
}
