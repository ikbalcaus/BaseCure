import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginRedirectService {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  role: string | undefined = this.authService.getAuthToken()?.korisnik?.uloga;

  redirect() {
    if(this.role == "korisnik") {
      this.router.navigateByUrl("/pretrazi");
    }
    else if(this.role == "ustanova-zdravstva") {
      this.router.navigateByUrl("/ustanova-zdravstva/karton");
    }
    else if(this.role == "admin") {
      this.router.navigateByUrl("/basecure-admin/dashboard");
    }
  }
}
