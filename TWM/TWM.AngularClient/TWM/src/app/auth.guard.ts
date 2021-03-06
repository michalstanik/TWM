// auth.guard.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { OpenIdConnectService } from './shared/services/open-id-connect.service';
import { AuthService } from './core/auth.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private _authService: AuthService, private router: Router) { }

  canActivate() {

    console.log("1.AuthGuard/canActivate/openIdConnectService.userAvailable: ", this._authService.isLoggedIn());
    
    //this.openIdConnectService.getUser();
    if (this._authService.isLoggedIn()) {
      return true;
    }
    else {
      // trigger signin
      return false;
    }
  }
}
