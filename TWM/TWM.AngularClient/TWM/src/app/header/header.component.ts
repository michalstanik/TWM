import { Component } from '@angular/core';

import { OpenIdConnectService } from '../shared/services/open-id-connect.service';
import { AuthService } from '../core/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent {

  constructor(
    private _authService: AuthService
  ) {

  }

  logout() {
    this._authService.logout();
  }


  isLoggedIn() {
    return this._authService.isLoggedIn();
  }

}
