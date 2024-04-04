import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { AuthToken } from "../endpoints/authToken";
import { backendSettings } from "../backend-settings";
import { AlertService } from "./alert.service";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })

export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertService: AlertService
  ) {}

  isLoggedIn() {
    return window.localStorage.getItem("auth-token") != null;
  }

  getAuthToken(): AuthToken | null {
    try {
      return JSON.parse(window.localStorage.getItem("auth-token") || "");
    }
    catch(error) {
      return null;
    }
  }

  loginUser(authRoute: string, req: any): Observable<any> {
    return this.httpClient.post(backendSettings.address + authRoute, req);
  }

  verifyCode(req: any) {
    return this.httpClient.post<any>(backendSettings.address + "/verify-code", req);
  }

  logoutUser() {
    window.localStorage.removeItem("auth-token");
    this.router.navigateByUrl("/");
  }
}
