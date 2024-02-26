import { Injectable } from '@angular/core';
import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })

export class InterceptorService implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const header = req.clone({
      headers: req.headers.set("auth-token", this.authService.getAuthToken()?.vrijednost || "")
    });
    return next.handle(header);
  }
}
