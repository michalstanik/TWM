import { Component } from '@angular/core';

import { OpenIdConnectService } from '../shared/services/open-id-connect.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
 
  constructor(private openIdConnectService: OpenIdConnectService) { }   
}
