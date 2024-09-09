import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })

export class RedirectService {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}
  
  canActivate(): boolean {
    if(!this.authService.isLoggedIn()) return true;
    const role = this.authService.getAuthToken()?.uloga;
    if(role == "korisnik") this.router.navigateByUrl("/pretrazi");
    else if(role == "apoteka") this.router.navigateByUrl("/apoteka/narudzbe");
    else if(role == "bolnica") this.router.navigateByUrl("/ustanova-zdravstva/podaci");
    else if(role == "ljekar") this.router.navigateByUrl("/poruke");
    else if(role == "admin") this.router.navigateByUrl("/basecure-admin/dashboard");
    return false;
  }
}
