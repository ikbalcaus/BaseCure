import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { HttpClient } from '@angular/common/http';
import { serverSettings } from '../../../server-settings';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-user-cart',
  standalone: true,
  imports: [CommonModule, ItemListComponent],
  templateUrl: './user-cart.component.html',
  styleUrl: './user-cart.component.css'
})
export class UserCartComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {}

  korisnik: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/korisnici/" + this.authService.getAuthToken()!.korisnik!.korisnikId).subscribe(
      res => {
        this.korisnik = res
      }
    );
  }
}
