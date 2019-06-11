import { Component } from '@angular/core';

import { OpenIdConnectService } from './shared/services/open-id-connect.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TWM';

  constructor(private openIdConnectService: OpenIdConnectService) {
  }

}
