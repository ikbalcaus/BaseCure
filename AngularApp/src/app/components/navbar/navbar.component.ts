import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports: [CommonModule, RouterModule, RouterLinkActive],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.css'
})
export class NavbarComponent {
    constructor(private authService: AuthService) {}

    isLoggedIn() {
        return this.authService.isLoggedIn();
    }

    logoutUser() {
        this.authService.logoutUser();
    }

    showLink(role: string) {
        return role == this.authService.getAuthToken()?.korisnik?.uloga;
    }
}
