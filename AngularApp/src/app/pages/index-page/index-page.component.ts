import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-index-page',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './index-page.component.html',
    styleUrl: './index-page.component.css',
})
export class IndexPageComponent {
    constructor(private authService: AuthService) {}

    loginUser(data: any) {
        this.authService.loginUser("/auth/login", data);
    }
}
