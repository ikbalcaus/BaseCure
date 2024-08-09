import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-index-page',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './index-page.component.html',
    styleUrl: './index-page.component.css',
})
export class IndexPageComponent {
    isForgotPasswordModalOpen = false;

    constructor(private authService: AuthService, private router: Router) {}

    loginUser(data: any) {
        this.authService.loginUser("/auth/login", data);
    }

    openForgotPasswordModal() {
        this.isForgotPasswordModalOpen = true;
    }

    closeForgotPasswordModal() {
        this.isForgotPasswordModalOpen = false;
    }

    resetPassword(data: any) {
        if (data.newPassword !== data.confirmPassword) {
            this.authService.setAlert("danger", "Šifre se ne poklapaju!");
            return;
        }
        
        this.authService.checkEmailAndResetPassword(data.email, data.newPassword).subscribe(
            () => {
                this.authService.setAlert("success", "Šifra uspešno resetovana!");
                this.closeForgotPasswordModal();
            },
            () => {
                this.authService.setAlert("danger", "Došlo je do greške prilikom resetovanja šifre.");
            }
        );
    }
}
