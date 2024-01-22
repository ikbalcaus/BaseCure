import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { myCofnig } from '../../../myconfig';
import { HttpClient } from '@angular/common/http';
import { AuthToken } from '../../../endpoints/authToken';

@Component({
  selector: 'app-admin-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-login.component.html',
  styleUrl: './admin-login.component.css'
})
export class AdminLoginComponent {
  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) {}

  loginAdmin(req: any) {
    this.httpClient.post<AuthToken>(myCofnig.backendAddress + "/auth/admin-login", req).subscribe(
      res => {
        if(res == null) {
          alert("Pogresan username ili password");
        }
        else {
          window.sessionStorage.setItem("auth-token", JSON.stringify(res));
          this.router.navigateByUrl("/basecure-admin/dashboard");
        }
      }
    );
  }
}
