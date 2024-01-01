import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

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
        private router: Router
    ) {}

    ngOnInit() {
        if (this.authService.isLogiran()) this.router.navigate(["/korisnik-info"]);
    }
    
    loginUser(data: any) {
        this.authService.loginUser(data);
    }
}
