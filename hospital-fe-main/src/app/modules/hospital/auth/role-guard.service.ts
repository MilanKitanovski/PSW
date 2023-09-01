import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {AuthService} from "./auth.service";
import {Observable} from "rxjs";
import decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate{

  constructor(private auth: AuthService,
              private router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const expectedRole = route.data['role'];
    const token = localStorage.getItem("token")

    if (token) {
      const tokenPayload : any = decode(token);
      if(!this.auth.isAuthenticated() || !expectedRole.includes(tokenPayload.role)){
        this.router.navigate(["home"]);
        return false;
      }else{
        return true;
      }
    }
    if(expectedRole.includes("anon")){
      return true;
    }

    this.router.navigate(["home"]);
    return false;
  }
}
