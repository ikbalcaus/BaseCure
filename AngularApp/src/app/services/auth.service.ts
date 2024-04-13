import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { backendSettings } from "../backend-settings";
import { AlertService } from "./alert.service";

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

  getAuthToken() {
    try {
      return JSON.parse(window.localStorage.getItem("auth-token") || "");
    }
    catch(error) {
      return null;
    }
  }

  loginUser(authRoute: string, req: any) {
    this.httpClient.post<any>(backendSettings.address + authRoute, req).subscribe(
      res => {
        if(res == null) {
          this.alertService.setAlert("danger", "Korisnik ne postoji");
        }
        else {
          window.localStorage.setItem("auth-token", JSON.stringify(res));
          if(res.korisnik.uloga == "korisnik") this.router.navigateByUrl("/korisnik-info");
          else if(res.korisnik.uloga == "apoteka") this.router.navigateByUrl("/apoteka/lijekovi");
        }
      }
    );
  }

  logoutUser() {
    window.localStorage.removeItem("auth-token");
    this.router.navigateByUrl("/");
  }
}
