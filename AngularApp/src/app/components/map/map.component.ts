import { Component, Input } from '@angular/core';
import * as L from 'leaflet';
import { serverSettings } from '../../server-settings';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})
export class MapComponent {
  constructor(private httpClient: HttpClient) {}

  private map: any;
  @Input() medicalInstitutionId: any;
  lat: any;
  long: any;

  ngOnInit() {
    this.httpClient.get<any>(serverSettings.address + "/ustanoveZdravstva/latlong/" + this.medicalInstitutionId).subscribe(
      res => {
        this.lat = res.lat;
        this.long = res.long;
        this.initMap();
      }
    )
  }

  initMap() {
    this.map = L.map("map", {
      center: [ this.lat, this.long ],
      zoom: 17
    });
    const tiles = L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
      maxZoom: 18,
      minZoom: 7
    });
    tiles.addTo(this.map);
    
    const redIcon = L.icon({
      iconUrl: "https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png",
      iconSize: [20, 30],
      iconAnchor: [12, 41],
      popupAnchor: [1, -34],
      shadowUrl: "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png",
      shadowSize: [31, 31] 
    });
    L.marker([this.lat, this.long], { icon: redIcon }).addTo(this.map);
  }
}
