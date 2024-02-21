import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { LoginRedirectService } from '../../services/login-redirect.service';

@Component({
    selector: 'app-landing-page',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './landing-page.component.html',
    styleUrl: './landing-page.component.css',
})
export class LandingPageComponent {
    constructor(
        private authService: AuthService,
        private loginRedirectService: LoginRedirectService
    ) {}

    ngOnInit() {
        this.loginRedirectService.redirect();
    }

    formSubmit(data: any) {
        this.authService.loginUser(data);
    }
}
