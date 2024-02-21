import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { AuthToken } from "../endpoints/authToken";
import { myCofnig } from "../myconfig";

@Injectable({ providedIn: 'root' })

export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router
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

  loginUser(req: any) {
    this.httpClient.post(myCofnig.backendAddress + "/auth/login", req).subscribe(
      res => {
        if(res == null) {
          alert("Pogresan username ili password");
        }
        else {
          window.localStorage.setItem("auth-token", JSON.stringify(res));
          this.router.navigateByUrl("/korisnik-info");
        }
      }
    );
  }

  logoutUser() {
    window.localStorage.removeItem("auth-token");
    this.router.navigateByUrl("/");
  }
}
