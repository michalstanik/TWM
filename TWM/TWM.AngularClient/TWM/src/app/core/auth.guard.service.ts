// auth.guard.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './auth.service';


@Injectable()
export class AuthGuardService implements CanActivate {

  _authService: AuthService

  constructor(private authService: AuthService, private router: Router) {
    this._authService = authService;
  }

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
