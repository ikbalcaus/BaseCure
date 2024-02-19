import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { myCofnig } from '../../../myconfig';
import { HttpClient } from '@angular/common/http';
import { LoginRedirectService } from '../../../services/login-redirect.service';

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
    private router: Router,
    private loginRedirectService: LoginRedirectService
  ) {}

  ngOnInit() {
    this.loginRedirectService.redirect();
  }

  loginAdmin(req: any) {
    this.httpClient.post(myCofnig.backendAddress + "/auth/admin-login", req).subscribe(
      res => {
        if(res == null) {
          alert("Pogresan username ili password");
        }
        else {
          window.localStorage.setItem("auth-token", JSON.stringify(res));
          this.router.navigateByUrl("/basecure-admin/dashboard");
        }
      }
    );
  }
}
