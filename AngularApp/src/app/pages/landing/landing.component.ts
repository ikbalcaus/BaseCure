import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-landing',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './landing.component.html',
    styleUrl: './landing.component.css',
})
export class LandingComponent implements OnInit {
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
