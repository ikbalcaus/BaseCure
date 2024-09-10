import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { serverSettings } from "../server-settings";
import { AlertService } from "./alert.service";

@Injectable({ providedIn: 'root' })

export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertService: AlertService
  ) {}

  isLoggedIn() {
    return window.localStorage.getItem("auth-token") != null || window.sessionStorage.getItem("auth-token") != null;
  }

  getAuthToken() {
    try {
      const token = window.localStorage.getItem("auth-token") || window.sessionStorage.getItem("auth-token") || "";
      return JSON.parse(token);
    }
    catch(error) {
      return null;
    }
  }

  loginUser(authRoute: string, req: any) {
    this.httpClient.post<any>(serverSettings.address + authRoute, req).subscribe(
      res => {
        if(req.rememberme) {
          window.localStorage.setItem("auth-token", JSON.stringify(res));
          window.sessionStorage.removeItem("auth-token");
        }
        else {
          window.localStorage.removeItem("auth-token");
          window.sessionStorage.setItem("auth-token", JSON.stringify(res));
        }
        if(res.uloga == "korisnik") this.router.navigateByUrl("/pretrazi");
        else if(res.uloga == "apoteka") this.router.navigateByUrl("/apoteka/narudzbe");
        else if(res.uloga == "bolnica") this.router.navigateByUrl("/ustanova-zdravstva/podaci");
        else if(res.uloga == "ljekar") this.router.navigateByUrl("/poruke");
        else if(res.uloga == "admin") this.router.navigateByUrl("/basecure-admin/dashboard");
      },
      () => this.alertService.setAlert("danger", "Niste unijeli ispravne podatke")
    );
  }

  logoutUser() {
    window.localStorage.removeItem("auth-token");
    window.sessionStorage.removeItem("auth-token");
    this.router.navigateByUrl("/");
  }
}
