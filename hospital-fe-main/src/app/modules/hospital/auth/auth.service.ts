import { Injectable } from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public jwtHelper : JwtHelperService) { }

  public isAuthenticated(){
    const token = localStorage.getItem("token");
    if (token) {
      return !this.jwtHelper.isTokenExpired(token);
    }
    return false;
  }
  public getUserRole() {
    const token = localStorage.getItem("token");
    if (token) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      if (decodedToken && decodedToken.role) {
        return decodedToken.role;
      }
    }
    return null; // Return an appropriate default value if role is not found
  }
}
