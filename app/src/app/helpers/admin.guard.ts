import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import * as jwt_decode from 'jwt-decode';

import { AuthService } from "../services/auth.service";

@Injectable({ providedIn: 'root' })
export class AdminGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let authData = this.authService.currentAuthData;
    if (authData) {
      let token = authData.token;
      let jwtPayload = jwt_decode(token);

      // allow only admin enter to the area
      return "Admin" == jwtPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    }

    // access to admine area denied
    this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
