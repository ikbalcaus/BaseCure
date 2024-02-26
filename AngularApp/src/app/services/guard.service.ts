import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { ActivatedRouteSnapshot, Router } from '@angular/router';

@Injectable({ providedIn: 'root' })

export class GuardService {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {}
  
  canActivate(route: ActivatedRouteSnapshot): boolean {
    if(route.data["role"] == this.authService.getAuthToken()?.korisnik?.uloga) {
      return true;
    }
    this.router.navigateByUrl("/");
    return false;
  }
}
