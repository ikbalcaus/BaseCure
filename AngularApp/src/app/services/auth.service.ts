import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { AuthToken } from "../endpoints/authToken";
import { myCofnig } from "../myconfig";

@Injectable({providedIn: 'root'})

export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) {}

  isLogiran(): boolean {
    return window.localStorage.getItem("auth-token") != null;
  }

  getAuthToken(): AuthToken | null {
    try {
      return JSON.parse(window.localStorage.getItem("auth-token") ?? "");
    }
    catch(error) {
      return null;
    }
  }

  loginUser(data: any) {
    this.httpClient.post<AuthToken>(myCofnig.backendAddress + "/auth/login", data).subscribe(
      AuthToken => {
        if(AuthToken == null) {
          alert("Pogresan username ili password");
        }
        else {
          window.localStorage.setItem("auth-token", JSON.stringify(AuthToken));
          this.router.navigate(["/korisnik-info"]);
        }
      }
    );
  }

  logoutUser() {
    window.localStorage.removeItem("auth-token");
    this.router.navigate(["/"]);
  }
}
