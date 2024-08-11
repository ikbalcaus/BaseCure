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
    if(!route.data["roles"].includes(this.authService.getAuthToken()?.uloga)) {
      this.router.navigateByUrl("/");
      return false;
    }
    return true;
  }
}
