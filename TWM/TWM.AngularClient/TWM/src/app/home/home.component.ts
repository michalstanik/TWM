import { Component, OnInit } from '@angular/core';

import { OpenIdConnectService } from '../shared/services/open-id-connect.service';
import { AuthService } from '../core/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  private islooged: boolean;
  constructor(
    private _authService: AuthService
  ) {}


  ngOnInit() {

  }

  login() {
    this._authService.login();
  }

  isLoggedIn() {
    console.log("this._authService.isLoggedIn()", this._authService.isLoggedIn());
    return this._authService.isLoggedIn();
  }
}
