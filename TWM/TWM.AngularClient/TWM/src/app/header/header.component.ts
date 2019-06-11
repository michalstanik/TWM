import { Component } from '@angular/core';

import { OpenIdConnectService } from '../shared/services/open-id-connect.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent {

  constructor(private openIdConnectService: OpenIdConnectService) {

  }


}
