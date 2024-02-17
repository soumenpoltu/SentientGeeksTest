import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private route: Router, private jwthelper: JwtHelperService) { }
  canActivate() {
    let token = sessionStorage.getItem("token");
    if (token && !this.jwthelper.isTokenExpired(token)) {
      return true;

    }
    this.route.navigate(['']);
    return false;


  }

}
