import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { myCofnig } from '../../my-config';

@Component({
    selector: 'app-landing',
    standalone: true,
    imports: [CommonModule, FormsModule, HttpClientModule],
    templateUrl: './landing.component.html',
    styleUrl: './landing.component.css',
})
export class LandingComponent {
    constructor(private httpClient: HttpClient) {}

    sendLoginPostRequest(data: any) {
        this.httpClient.post(myCofnig.backendAddress, data);
    }
}
