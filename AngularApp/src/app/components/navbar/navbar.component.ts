import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-navbar',
    standalone: true,
    imports: [CommonModule, RouterModule, RouterLinkActive, TranslateModule],
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.css',
})
export class NavbarComponent {
    constructor(
        private authService: AuthService,
        private translate: TranslateService
    ) {}

    language: any;

    ngOnInit() {
        this.language = window.localStorage.getItem("language") || "ba";
    }

    isLoggedIn() {
        return this.authService.isLoggedIn();
    }

    logoutUser() {
        this.authService.logoutUser();
    }

    showLink(roles: Array<string>) {
        return roles.includes(this.authService.getAuthToken()?.uloga);
    }

    changeLanguage(event: any) {
        const language = (event.target as HTMLSelectElement).value;
        this.translate.use(language);
        window.localStorage.setItem("language", language);
    }
}
