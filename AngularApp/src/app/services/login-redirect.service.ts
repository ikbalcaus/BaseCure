import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })

export class LoginRedirectService {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}
  
  canActivate(): boolean {
    if(!this.authService.isLoggedIn()) {
      return true;
    }
    let role = this.authService.getAuthToken()?.korisnik?.uloga;
    if(role == "korisnik") {
      this.router.navigateByUrl("/pretrazi");
    }
    else if(role == "ustanova-zdravstva") {
      this.router.navigateByUrl("/ustanova-zdravstva/karton");
    }
    else if(role == "admin") {
      this.router.navigateByUrl("/basecure-admin/dashboard");
    }
    return false;
  }
}
