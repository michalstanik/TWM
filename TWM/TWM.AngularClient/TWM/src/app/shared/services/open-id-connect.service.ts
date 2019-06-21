import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';
import { ReplaySubject } from 'rxjs';
import { Console } from '@angular/core/src/console';

@Injectable()
export class OpenIdConnectService {

  private userManager: UserManager = new UserManager(environment.openIdConnectSettings);
  private currentUser: User = null;

  userLoaded$ = new ReplaySubject<boolean>(1);

  isLoggedIn(): boolean {
    return this.currentUser != null && !this.currentUser.expired;
  }

  get userAvailable(): boolean {
    if (this.currentUser != null) {
      return true;
    }
  }

  get user(): User {
    return this.currentUser;
  }

  constructor() {
    this.userManager.clearStaleState();

    this.userManager.getUser().then(user => {
      this.currentUser = user;
    });

    this.userManager.events.addUserLoaded(user => {
      if (!environment.production) {
        console.log('User loaded.', user);
      }
      this.currentUser = user;
      //
      this.getUser();
      this.userLoaded$.next(true);
    });

    this.userManager.events.addUserUnloaded((e) => {
      if (!environment.production) {
        console.log('User unloaded');
      }
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }

  getUser() {
    this.userManager.getUser().then(user => {
      this.currentUser = user;
      console.log("getUser:", this.currentUser);
    });
  }

  triggerSignIn():Promise<void> {
    return this.userManager.signinRedirect().then(function () {
      if (!environment.production) {
        console.log('Redirection to signin triggered.');
      }
    });
  }

  triggerSignOut() {
    this.userManager.signoutRedirect().then(function (resp) {
      if (!environment.production) {
        console.log('Redirection to sign out triggered.', resp);
      }
    });
  };

  handleCallback(): Promise<void>  {
    return this.userManager.signinRedirectCallback().then(function (user) {
      if (!environment.production) {
        console.log('Callback after signin handled.', user);
        this.currentUser = user;
      }
    });
  }
}
