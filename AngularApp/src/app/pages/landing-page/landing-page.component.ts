import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from '../../services/auth.service';
import { VerificationModalComponent } from '../verification-modal/verification-modal.component';

@Component({
    selector: 'app-landing-page',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './landing-page.component.html',
    styleUrl: './landing-page.component.css',
})
export class LandingPageComponent {
    constructor(private authService: AuthService, private dialog: MatDialog) { }

    formSubmit(data: any) {
        this.authService.loginUser("/auth/login", data).subscribe(
            () => {
                // Open verification modal
                this.openVerificationModal();
            },
            error => {
                console.error(error); // Handle login error
                // Display error message to the user
            }
        );
    }

    verifyCode(data: any) {
        // Call AuthService to verify the code
        this.authService.verifyCode(data)
            .subscribe(
                response => {
                    console.log(response); // Handle verification success
                    // Redirect or perform further actions after successful verification
                },
                error => {
                    console.error(error); // Handle verification error
                    // Display error message to the user
                }
            );
    }

    openVerificationModal() {
        // Open the verification modal dialog
        this.dialog.open(VerificationModalComponent, {
            width: '400px', // Adjust width as needed
            disableClose: true, // Prevent closing by clicking outside or pressing ESC key
            autoFocus: false // Disable auto-focusing on the first focusable element inside the modal
        });
    }
}
