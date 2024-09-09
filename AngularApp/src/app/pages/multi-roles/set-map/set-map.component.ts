import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import * as L from 'leaflet';
import { AuthService } from '../../../services/auth.service';
import { AlertService } from '../../../services/alert.service';
import { serverSettings } from '../../../server-settings';
import { CommonModule } from '@angular/common';
import { ModalComponent } from '../../../components/modal/modal.component';
import { Router } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-set-map',
  standalone: true,
  imports: [CommonModule, ModalComponent, TranslateModule],
  templateUrl: './set-map.component.html',
  styleUrl: './set-map.component.css'
})
export class SetMapComponent {
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService,
    private router: Router,
    private alertService: AlertService
  ) {}

  map!: L.Map;
  showModal: boolean = false;
  lat: any;
  long: any;
  marker: any = L.icon({
    iconUrl: "https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png",
    iconSize: [20, 30],
    iconAnchor: [12, 41],
    popupAnchor: [1, -34],
    shadowUrl: "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png",
    shadowSize: [31, 31]
  });

  ngOnInit() {
    this.httpClient.get<any>(serverSettings.address + "/ustanoveZdravstva/latlong/" + this.authService.getAuthToken().ustanovaId).subscribe(
      res => {
        this.lat = res.lat;
        this.long = res.long;
        this.initMap();
      }
    );
  }

  initMap() {
    this.map = L.map("map", {
      center: [this.lat || 43.8563, this.long || 18.4131],
      zoom: 17
    });
    const tiles = L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
      maxZoom: 18,
      minZoom: 7
    });
    tiles.addTo(this.map);
    if(this.lat && this.long) L.marker([this.lat, this.long], { icon: this.marker }).addTo(this.map);
    this.map.on("click", event => {
      this.onMapClick(event);
    });
  }
  onMapClick(event: L.LeafletMouseEvent) {
    this.lat = event.latlng.lat;
    this.long = event.latlng.lng;
    this.map.eachLayer(layer => {
      if(layer instanceof L.Marker) this.map.removeLayer(layer);
    });
    L.marker([this.lat, this.long], { icon: this.marker }).addTo(this.map);
  }

  saveLocation() {
    this.httpClient.patch(serverSettings.address + "/ustanoveZdravstva/" + this.authService.getAuthToken().ustanovaId, { lat: this.lat, long: this.long }).subscribe(
      () => {
        this.router.navigateByUrl("/");
        this.alertService.setAlert("success", "Uspješno ste sačuvali lokaciju");
      }
    )
  }
}