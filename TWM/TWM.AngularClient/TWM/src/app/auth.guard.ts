// auth.guard.ts
import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { OpenIdConnectService } from './shared/services/open-id-connect.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private openIdConnectService: OpenIdConnectService, private router: Router) { }

  canActivate() {

    console.log("1.AuthGuard/canActivate/openIdConnectService.userAvailable: ", this.openIdConnectService.userAvailable);
    
    //this.openIdConnectService.getUser();
    if (this.openIdConnectService.userAvailable) {
      return true;
    }
    else {
      // trigger signin
      this.openIdConnectService.triggerSignIn();
      return false;
    }
  }
}
