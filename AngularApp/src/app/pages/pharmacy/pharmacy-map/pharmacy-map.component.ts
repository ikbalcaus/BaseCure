import { Component } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-pharmacy-map',
  standalone: true,
  imports: [],
  templateUrl: './pharmacy-map.component.html',
  styleUrl: './pharmacy-map.component.css'
})
export class PharmacyMapComponent {
  private map!: L.Map;

  private initMap(): void {
    this.map = L.map("map", {
      center: [43.8563, 18.4131],
      zoom: 13
    });

    const tiles = L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
      maxZoom: 18,
      minZoom: 7
    });
    tiles.addTo(this.map);

    this.map.on("click", event => {
      this.onMapClick(event);
    });
  }

  private onMapClick(event: L.LeafletMouseEvent): void {
    const latitude = event.latlng.lat;
    const longitude = event.latlng.lng;
    this.map.eachLayer((layer) => {
      if (layer instanceof L.Marker) {
        this.map.removeLayer(layer);
      }
    });

    const redIcon = L.icon({
      iconUrl: "https://cdn.rawgit.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png",
      iconSize: [20, 30],
      iconAnchor: [12, 41],
      popupAnchor: [1, -34],
      shadowUrl: "https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png",
      shadowSize: [31, 31]
    });
    L.marker([latitude, longitude], { icon: redIcon }).addTo(this.map);
  }

  ngAfterViewInit() {
    this.initMap();
  }
}