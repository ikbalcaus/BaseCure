import { CommonModule } from '@angular/common';
import { Component, NgIterable } from '@angular/core';
import { ItemListComponent } from '../../../components/item-list/item-list.component';
import { ModalComponent } from '../../../components/modal/modal.component';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../../services/auth.service';
import { serverSettings } from '../../../server-settings';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-pharmacy-orders',
  standalone: true,
  imports: [CommonModule, ItemListComponent, ModalComponent, RouterModule, TranslateModule],
  templateUrl: './pharmacy-orders.component.html',
  styleUrl: './pharmacy-orders.component.css'
})
export class PharmacyOrdersComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
  ) {}

  res: any;

  ngOnInit() {
    this.httpClient.get(serverSettings.address + "/narudzbe/apoteka/" + this.authService.getAuthToken().ustanovaId).subscribe(
      res => this.res = res
    );
  }

  countOrders(status: string): number {
    return this.res.filter((x: any) => x.status == status).length || 0;
  }
}
