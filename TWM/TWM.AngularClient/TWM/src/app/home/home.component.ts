import { Component, OnInit } from '@angular/core';

import { OpenIdConnectService } from '../shared/services/open-id-connect.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  private islooged: boolean;
  constructor(private openIdConnectService: OpenIdConnectService) { }

  ngOnInit() {
    this.islooged = this.openIdConnectService.userAvailable;
  }
}
