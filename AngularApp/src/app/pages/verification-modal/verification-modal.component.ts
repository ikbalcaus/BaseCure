import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../services/auth.service'; // Import your AuthService
import { MatFormFieldModule } from '@angular/material/form-field';

// Define the component


@Component({
  selector: 'app-verification-modal',
  standalone: true,
  imports: [MatFormFieldModule],
  templateUrl: './verification-modal.component.html',
  styleUrl: './verification-modal.component.css'
})
export class VerificationModalComponent {
  constructor(
    public dialogRef: MatDialogRef<VerificationModalComponent>,
    private authService: AuthService // Inject your AuthService
  ) { }

  close(): void {
    // Close the modal
    this.dialogRef.close();
  }

  submitVerificationCode(verificationCode: string) {
    // Call your service method to verify the code
    this.authService.verifyCode({ verificationCode }).subscribe(
      response => {
        // Handle verification success
        console.log('Verification successful:', response);
        this.dialogRef.close(); // Close the modal
        // You can perform additional actions here, such as redirecting the user
      },
      error => {
        // Handle verification error
        console.error('Verification failed:', error);
        // You can display an error message to the user or retry verification
      }
    );
  }
}
