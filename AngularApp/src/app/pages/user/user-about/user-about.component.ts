import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { UstanovaZdravstva } from '../../../endpoints/ustanoveZdravstva';
import { myCofnig } from '../../../myconfig';

@Component({
  selector: 'app-user-about',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-about.component.html',
  styleUrl: './user-about.component.css'
})
export class UserAboutComponent {
  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {}

  res: UstanovaZdravstva = {
    ustanovaId: 0,
    naziv: "",
    //opis: "",
    grad: "",
    adresa: "",
    kontaktBroj: "",
    email: ""
  };

  ngOnInit() {
    this.httpClient.get<UstanovaZdravstva>(myCofnig.backendAddress + "/ustanveZdravstva/" + this.route.snapshot.paramMap.get("id")).subscribe(
      res => {
        this.res = res;
      }
    );
  }
}
