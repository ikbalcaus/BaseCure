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
    for(let role of route.data["roles"]) {
      if(role == this.authService.getAuthToken()?.uloga) return true;
    }
    this.router.navigateByUrl("/");
    return false;
  }
}
