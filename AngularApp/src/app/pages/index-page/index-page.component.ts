import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { TranslateModule } from '@ngx-translate/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-index-page',
    standalone: true,
    imports: [CommonModule, FormsModule, TranslateModule],
    templateUrl: './index-page.component.html',
    styleUrl: './index-page.component.css',
})
export class IndexPageComponent {
    constructor(private authService: AuthService) {}

    loginUser(data: any) {
        this.authService.loginUser("/auth/login", data);
    }
}
